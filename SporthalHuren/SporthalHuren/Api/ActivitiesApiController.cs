using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SporthalHuren.Models;
using Halcyon.HAL;
using Halcyon.Web.HAL;

namespace SporthalHuren.Api
{
    [Produces("application/json")]
    [Route("api/v1/Activities")]
    public class ActivitiesApiController : Controller
    {
        private IActivityRepository repository;

        public ActivitiesApiController(IActivityRepository repo)
        {
            repository = repo;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<Activity> Activities = repository.Activities.ToList();
            return Ok(Activities);
        }

        [HttpGet("{id}")] //route param
        public IActionResult Get(int id)
        {
            var Activity = repository.Activities.SingleOrDefault(x => x.ID == id);
            if (Activity == null)
            {
                return NoContent();
            }
            return this.HAL(Activity, new Link[] {
                new Link("self", "/api/v1/Activities/" + id)
            });
        }
        [HttpPost]
        public IActionResult Post([FromBody]Activity Activity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            repository.SaveActivity(Activity);
            return CreatedAtAction(nameof(Get),
                new { id = Activity.ID }, Activity);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Activity Activity)
        {
            if (Activity == null || id != Activity.ID)
            {
                return BadRequest();
            }
            var activity = repository.Activities.SingleOrDefault(x => x.ID == id);
            if (activity == null)
            {
                return NotFound();
            }
            repository.EditActivity(Activity);
            return CreatedAtAction(nameof(Get),
                new { id = Activity.ID }, Activity);

        }

        [HttpPut]
        public IActionResult Put([FromBody] List<Activity> Activities)
        {
            if (Activities.Count == 0)
            {
                return BadRequest();
            }
            List<Activity> Acts = new List<Activity>();
            foreach (var p in Activities)
            {
                foreach (var t in repository.Activities)
                {
                    if (p.ID == t.ID)
                    {
                        Acts.Add(p);
                    }
                }
            }
            if (Acts.Count == 0)
            {
                return NotFound();
            }
            foreach (var activity in Acts)
            {
                repository.EditActivity(activity);
            }
            return Get();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Activity = repository.Activities.SingleOrDefault(x => x.ID == id);
            if (Activity == null)
            {
                return NotFound();
            }
            repository.DeleteActivity(id);
            return Get();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            List<Activity> Activities = repository.Activities.ToList();
            foreach (var p in Activities)
            {
                repository.DeleteActivity(p.ID);
            }
            return Get();
        }
    }
}
