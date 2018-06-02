using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SporthalHuren.Models.Repository;
using SporthalHuren.Models.Domain;
using Halcyon.Web.HAL;
using Halcyon.HAL;
using System.Diagnostics;

namespace SporthalHuren.Api
{
    [Produces("application/json")]
    [Route("api/v1/Bookings")]
    public class BookingsApiController : Controller
    {
        private IBookingRepository repository;

        public BookingsApiController(IBookingRepository repo)
        {
            repository = repo;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<Booking> Bookings = repository.Bookings.ToList();

            return Ok(Bookings);
        }
        [HttpGet("Hall/{id}")]
        public IActionResult GetHallBookings(int id)
        {
            List<Booking> Bookings = repository.Bookings.Where(x => x.HallID == id).ToList();

            return Ok(Bookings);
        }
        [HttpGet("Date/{id}")]
        public IActionResult GetBookingsWithDate(int id)
        {
            DateTime today = DateTime.Now.Date;
            List<Booking> Bookings = repository.Bookings.Where(x => x.Date.Date == today && x.HallID == id).ToList();
            return Ok(Bookings);
        }
        [HttpGet("{id}")] //route param
        public IActionResult Get(int id)
        {
            var Booking = repository.Bookings.SingleOrDefault(x => x.ID == id);
            if (Booking == null)
            {
                return NoContent();
            }
            return this.HAL(Booking, new Link[] {
                new Link("self", "/api/v1/Bookings/" + id),
                new Link("hall", "/api/v1/Halls/" + Booking.HallID),
                new Link("room", "api/v1/Rooms/" + Booking.RoomID),
                new Link("activity", "api/v1/Activities/" + Booking.ActivityID)
            });
        }

        [HttpGet("Hall/{id}/Booking/{date}")]
        public IActionResult GetByDay(int id, DateTime date)
        {
            List<Booking> bookings = repository.Bookings
                .Where(x => x.HallID == id && x.Date == date) 
                .ToList();

            return Ok(bookings);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Booking Booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            repository.SaveBooking(Booking);
            return CreatedAtAction(nameof(Get),
                new { id = Booking.ID }, Booking);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Booking Booking)
        {
            if (Booking == null || id != Booking.ID)
            {
                return BadRequest();
            }
            var b = repository.Bookings.SingleOrDefault(x => x.ID == id);
            if (b == null)
            {
                return NotFound();
            }
            repository.EditBooking(Booking);
            return CreatedAtAction(nameof(Get),
                new { id = Booking.ID }, Booking);

        }

        [HttpPut]
        public IActionResult Put([FromBody] List<Booking> Bookings)
        {
            if (Bookings.Count == 0)
            {
                return BadRequest();
            }
            List<Booking> bookings = new List<Booking>();
            foreach (var p in Bookings)
            {
                foreach (var t in repository.Bookings)
                {
                    if (p.ID == t.ID)
                    {
                        bookings.Add(p);
                    }
                }
            }
            if (bookings.Count == 0)
            {
                return NotFound();
            }
            foreach (var booking in bookings)
            {
                repository.EditBooking(booking);
            }
            return Get();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Booking = repository.Bookings.SingleOrDefault(x => x.ID == id);
            if (Booking == null)
            {
                return NotFound();
            }
            repository.DeleteBooking(id);
            return Get();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            List<Booking> Bookings = repository.Bookings.ToList();
            foreach (var p in Bookings)
            {
                repository.DeleteBooking(p.ID);
            }
            return Get();
        }
    }
}