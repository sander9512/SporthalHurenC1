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
    [Route("api/v1/Proprietors")]
    public class ProprietorsApiController : Controller
    {
        private IProprietorRepository repository;

        public ProprietorsApiController(IProprietorRepository repo)
        {
            repository = repo;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<Proprietor> Proprietors = repository.Proprietors.ToList();

            return Ok(Proprietors);
        }
        [HttpGet("{id}")] //route param
        public IActionResult Get(int id)
        {
            var Proprietor = repository.Proprietors.SingleOrDefault(x => x.ID == id);
            if (Proprietor == null)
            {
                return NoContent();
            }
            return Ok(Proprietor);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Proprietor Proprietor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            repository.SaveProprietor(Proprietor);
            return CreatedAtAction(nameof(Get),
                new { id = Proprietor.ID }, Proprietor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Proprietor Proprietor)
        {
            if (Proprietor == null || id != Proprietor.ID)
            {
                return BadRequest();
            }
            var Prop = repository.Proprietors.SingleOrDefault(x => x.ID == id);
            if (Prop == null)
            {
                return NotFound();
            }
            repository.EditProprietor(Proprietor);
            return CreatedAtAction(nameof(Get),
                new { id = Proprietor.ID }, Proprietor);

        }

        [HttpPut]
        public IActionResult Put([FromBody] List<Proprietor> Proprietors)
        {
            if(Proprietors.Count == 0)
            {
                return BadRequest();
            }
            List<Proprietor> Props = new List<Proprietor>();
            foreach(var p in Proprietors)
            {
               foreach(var t in repository.Proprietors)
                {
                    if (p.ID == t.ID)
                    {
                        Props.Add(p);
                    }
                }
            }
            if(Props.Count == 0)
            {
                return NotFound();
            }
            foreach (var proprietor in Props)
            {
                repository.EditProprietor(proprietor);
            }
            return Get();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Prop = repository.Proprietors.SingleOrDefault(x => x.ID == id);
            if(Prop == null)
            {
                return NotFound();
            }
            repository.DeleteProprietor(id);
            return Get();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            List<Proprietor> Props = repository.Proprietors.ToList();
            foreach(var p in Props)
            {
                repository.DeleteProprietor(p.ID);
            }
            return Get();
        }
    }
}