using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SporthalHuren.Models;
using Halcyon.Web.HAL;
using Halcyon.HAL;
using System.IO;
using System.Diagnostics;

namespace SporthalHuren.Api
{
    [Produces("application/json")]
    [Route("api/v1/OpeningTimes")]
    public class OpeningTimesApiController : Controller
    {
        private IOpeningTimeRepository repository;

        public OpeningTimesApiController(IOpeningTimeRepository repo)
        {
            repository = repo;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<OpeningTime> Times = repository.Times.ToList();

            return Ok(Times);
        }
        [HttpGet("{id}")] //route param
        public IActionResult Get(int id)
        {
            var Time = repository.Times.SingleOrDefault(x => x.ID == id);
            if (Time == null)
            {
                return NoContent();
            }
            return this.HAL(Time, new Link[] {
                new Link("self", "/api/v1/OpeningTimes/" + id),
                new Link("hall", "/api/v1/Halls/" + Time.HallID)
            });
        }

        [HttpPost]
        public IActionResult Post([FromBody]OpeningTime Time)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            repository.SaveTime(Time);
            return CreatedAtAction(nameof(Get),
                new { id = Time.ID }, Time);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] OpeningTime Time)
        {
            Debug.WriteLine(Time.Day);
            Debug.WriteLine(Time.TimeOpen);
            Debug.WriteLine(Time.TimeClose);
            Debug.WriteLine(id);
            Console.Write(id);
            if (Time == null)
            {
                return BadRequest();
            }
            var time = repository.Times.SingleOrDefault(x => x.ID == id);
            if (time == null)
            {
                return NotFound();
            }
            repository.EditTime(Time, id);
            return Ok(Time);

        }

        [HttpPut]
        public IActionResult Put([FromBody] List<OpeningTime> Times)
        {
            if (Times.Count == 0)
            {
                return BadRequest();
            }
            List<OpeningTime> times = new List<OpeningTime>();
            foreach (var p in Times)
            {
                foreach (var t in repository.Times)
                {
                    if (p.ID == t.ID)
                    {
                        times.Add(p);
                    }
                }
            }
            if (times.Count == 0)
            {
                return NotFound();
            }
            foreach (var time in times)
            {
                repository.EditTime(time, time.ID);
            }
            return Get();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Time = repository.Times.SingleOrDefault(x => x.ID == id);
            if (Time == null)
            {
                return NotFound();
            }
            repository.DeleteTime(id);
            return Get();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            List<OpeningTime> Times = repository.Times.ToList();
            foreach (var p in Times)
            {
                repository.DeleteTime(p.ID);
            }
            return Get();
        }

    }
}