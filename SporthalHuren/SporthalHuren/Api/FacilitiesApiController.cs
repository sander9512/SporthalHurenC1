using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SporthalHuren.Models.Domain_Services;
using SporthalHuren.Models;
using Halcyon.Web.HAL;
using Halcyon.HAL;

namespace SporthalHuren.Api
{
    [Produces("application/json")]
    [Route("api/v1/Facilities")]
    public class FacilitiesApiController : Controller
    {
        private IFacilityRepository repository;

        public FacilitiesApiController(IFacilityRepository repo)
        {
            repository = repo;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<Facility> Facilities = repository.Facilities.ToList();

            return Ok(Facilities);
        }
        [HttpGet("{id}")] //route param
        public IActionResult Get(int id)
        {
            var Facility = repository.Facilities.SingleOrDefault(x => x.ID == id);
            if (Facility == null)
            {
                return NoContent();
            }
            return this.HAL(Facility, new Link[] {
                new Link("self", "/api/v1/Facilities/" + id)

            });
        }

        [HttpPost]
        public IActionResult Post([FromBody]Facility Facility)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            repository.SaveFacility(Facility);
            return CreatedAtAction(nameof(Get),
                new { id = Facility.ID }, Facility);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Facility Facility)
        {
            if (Facility == null || id != Facility.ID)
            {
                return BadRequest();
            }
            var facility = repository.Facilities.SingleOrDefault(x => x.ID == id);
            if (facility == null)
            {
                return NotFound();
            }
            repository.EditFacility(Facility);
            return CreatedAtAction(nameof(Get),
                new { id = Facility.ID }, Facility);

        }

        [HttpPut]
        public IActionResult Put([FromBody] List<Facility> Facilities)
        {
            if (Facilities.Count == 0)
            {
                return BadRequest();
            }
            List<Facility> facilities = new List<Facility>();
            foreach (var p in Facilities)
            {
                foreach (var t in repository.Facilities)
                {
                    if (p.ID == t.ID)
                    {
                        facilities.Add(p);
                    }
                }
            }
            if (facilities.Count == 0)
            {
                return NotFound();
            }
            foreach (var facility in facilities)
            {
                repository.EditFacility(facility);
            }
            return Get();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Facility = repository.Facilities.SingleOrDefault(x => x.ID == id);
            if (Facility == null)
            {
                return NotFound();
            }
            repository.DeleteFacility(id);
            return Get();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            List<Facility> Facilities = repository.Facilities.ToList();
            foreach (var p in Facilities)
            {
                repository.DeleteFacility(p.ID);
            }
            return Get();
        }
    }
}