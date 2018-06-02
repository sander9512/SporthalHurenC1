using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SporthalHuren.Models.Domain_Services;
using SporthalHuren.Models;
using Halcyon.HAL;
using Halcyon.Web.HAL;

namespace SporthalHuren.Api
{
    [Produces("application/json")]
    [Route("api/v1/Rooms")]
    public class RoomsApiController : Controller
    {
        private IRoomRepository repository;

        public RoomsApiController(IRoomRepository repo)
        {
            repository = repo;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<Room> Rooms = repository.Rooms.ToList();

            return Ok(Rooms);
        }
        [HttpGet("{id}")] //route param
        public IActionResult Get(int id)
        {
            var Room = repository.Rooms.SingleOrDefault(x => x.ID == id);
            if (Room == null)
            {
                return NoContent();
            }
            return this.HAL(Room, new Link[] {
                new Link("self", "/api/v1/Rooms/" + id),
                new Link("hall", "/api/v1/Halls/" + Room.HallID)
            });
        }
        [HttpPost]
        public IActionResult Post([FromBody]Room Room)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            repository.SaveRoom(Room);
            return CreatedAtAction(nameof(Get),
                new { id = Room.ID }, Room);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Room Room)
        {
            if (Room == null || id != Room.ID)
            {
                return BadRequest();
            }
            var room = repository.Rooms.SingleOrDefault(x => x.ID == id);
            if (room == null)
            {
                return NotFound();
            }
            repository.EditRoom(Room);
            return CreatedAtAction(nameof(Get),
                new { id = Room.ID }, Room);

        }

        [HttpPut]
        public IActionResult Put([FromBody] List<Room> Rooms)
        {
            if (Rooms.Count == 0)
            {
                return BadRequest();
            }
            List<Room> rooms = new List<Room>();
            foreach (var p in Rooms)
            {
                foreach (var t in repository.Rooms)
                {
                    if (p.ID == t.ID)
                    {
                        rooms.Add(p);
                    }
                }
            }
            if (rooms.Count == 0)
            {
                return NotFound();
            }
            foreach (var room in rooms)
            {
                repository.EditRoom(room);
            }
            return Get();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Room = repository.Rooms.SingleOrDefault(x => x.ID == id);
            if (Room == null)
            {
                return NotFound();
            }
            repository.DeleteRoom(id);
            return Get();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            List<Room> Rooms = repository.Rooms.ToList();
            foreach (var p in Rooms)
            {
                repository.DeleteRoom(p.ID);
            }
            return Get();
        }

    }
}