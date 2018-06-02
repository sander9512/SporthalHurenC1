using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SporthalHuren.Models;
using Halcyon.HAL;
using Halcyon.Web.HAL;
using System.Diagnostics;

namespace SporthalHuren.Api
{
    [Produces("application/json")]
    [Route("api/v1/Halls")]
    public class HallsApiController : Controller
    {
        private ISportshallRepository repository;

        public HallsApiController(ISportshallRepository repo)
        {
            repository = repo;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<SportsHall> Halls = repository.Halls.ToList();
            return Ok(Halls);
        }
        [HttpGet("{id}")] //route param
        public IActionResult Get(int id)
        {
            var Hall = repository.Halls.SingleOrDefault(x => x.ID == id);
            if (Hall == null)
            {
                return NoContent();
            }
            List<Link> Links = new List<Link>();
            for (int i = 0; i < Hall.Rooms.Count(); i++)
            {
                Links.Add(new Link("room" + (i + 1), "api/v1/Rooms/" + Hall.Rooms.ElementAt(i).ID));
            }
            for (int t = 0; t < Hall.Times.Count(); t++)
            {
                Links.Add(new Link("time" + (t + 1), "api/v1/OpeningTimes/" + Hall.Times.ElementAt(t).ID));
            }
            Links.Add(new Link("proprietor", "api/v1/Proprietors/" + Hall.ProprietorID));

            return this.HAL(Hall, Links.ToArray());
    }
        [HttpGet("{id}/Rooms")]
        public IActionResult GetRooms(int id)
        {
            var Hall = repository.Halls.SingleOrDefault(x => x.ID == id);
            if (Hall == null)
            {
                return NoContent();
            }
            List<Room> Rooms = Hall.Rooms.ToList();
            var model = new
            {
                HallID = id,
                Count = Rooms.Count()
            };
            var response = new HALResponse(model)
                .AddEmbeddedCollection("halls", Rooms, new Link[]
                {
                    new Link("hall", "api/v1/Rooms/" + Rooms.First().ID)
                });
        
            return this.Ok(response);
               
        }
        [HttpGet("{id}/Times")]
        public IActionResult GetTimes(int id)
        {
            var Hall = repository.Halls.SingleOrDefault(x => x.ID == id);
            if (Hall == null)
            {
                return NoContent();
            }
            List<OpeningTime> Times = Hall.Times.ToList();
            var model = new
            {
                HallID = id,
                Count = Times.Count()
            };
            var response = new HALResponse(model)
                .AddEmbeddedCollection("times", Times, new Link[]
                {
                    new Link("hall", "api/v1/OpeningTimes/" + Times.First().ID)
                });

            return this.Ok(response);
        }
        [HttpGet("Proprietor/{id}")]
        public IActionResult GetPropHalls(int id)
        {
            Console.Write(id);
            var Halls = repository.Halls.Where(x => x.ProprietorID == id);
            Console.Write(Halls);
            if (Halls == null)
            {
                return NoContent();
            }
            List<SportsHall> List = Halls.ToList();
            return this.Ok(List);
        }
        [HttpPost]
        public IActionResult Post([FromBody]SportsHall Hall)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            repository.SaveSportsHall(Hall);
            return CreatedAtAction(nameof(Get),
                new { id = Hall.ID }, Hall);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SportsHall Hall)
        {
            if (Hall == null || id != Hall.ID)
            {
                return BadRequest();
            }
            var hall = repository.Halls.SingleOrDefault(x => x.ID == id);
            if (hall == null)
            {
                return NotFound();
            }
            repository.EditSportsHall(Hall);
            return CreatedAtAction(nameof(Get),
                new { id = Hall.ID }, Hall);

        }

        [HttpPut]
        public IActionResult Put([FromBody] List<SportsHall> Halls)
        {
            if (Halls.Count == 0)
            {
                return BadRequest();
            }
            List<SportsHall> halls = new List<SportsHall>();
            foreach (var p in Halls)
            {
                foreach (var t in repository.Halls)
                {
                    if (p.ID == t.ID)
                    {
                        halls.Add(p);
                    }
                }
            }
            if (halls.Count == 0)
            {
                return NotFound();
            }
            foreach (var hall in halls)
            {
                repository.EditSportsHall(hall);
            }
            return Get();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Hall = repository.Halls.SingleOrDefault(x => x.ID == id);
            if (Hall == null)
            {
                return NotFound();
            }
            repository.DeleteHall(id);
            return Get();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            List<SportsHall> Halls = repository.Halls.ToList();
            foreach (var p in Halls)
            {
                repository.DeleteHall(p.ID);
            }
            return Get();
        }
    }
}