using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SporthalHuren.Models;

namespace SporthalHuren.Api
{
    [Produces("application/json")]
    [Route("api/v1/Users")]
    public class UsersApiController : Controller
    {
        private IUserRepository repository;

        public UsersApiController(IUserRepository repo)
        {
            repository = repo;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<User> Users = repository.Users.ToList();

            return Ok(Users);
        }
        [HttpGet("{id}")] //route param
        public IActionResult Get(int id)
        {
            var User = repository.Users.SingleOrDefault(x => x.ID == id);
            if (User == null)
            {
                return NoContent();
            }
            return Ok(User);
        }

        [HttpPost]
        public IActionResult Post([FromBody]User User)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            repository.SaveUser(User);
            return CreatedAtAction(nameof(Get),
                new { id = User.ID }, User);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User User)
        {
            if (User == null || id != User.ID)
            {
                return BadRequest();
            }
            var user = repository.Users.SingleOrDefault(x => x.ID == id);
            if (user == null)
            {
                return NotFound();
            }
            repository.EditUser(User);
            return CreatedAtAction(nameof(Get),
                new { id = User.ID }, User);

        }

        [HttpPut]
        public IActionResult Put([FromBody] List<User> Users)
        {
            if (Users.Count == 0)
            {
                return BadRequest();
            }
            List<User> users = new List<User>();
            foreach (var p in Users)
            {
                foreach (var t in repository.Users)
                {
                    if (p.ID == t.ID)
                    {
                        users.Add(p);
                    }
                }
            }
            if (users.Count == 0)
            {
                return NotFound();
            }
            foreach (var user in users)
            {
                repository.EditUser(user);
            }
            return Get();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var User = repository.Users.SingleOrDefault(x => x.ID == id);
            if (User == null)
            {
                return NotFound();
            }
            repository.DeleteUser(id);
            return Get();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            List<User> Users = repository.Users.ToList();
            foreach (var p in Users)
            {
                repository.DeleteUser(p.ID);
            }
            return Get();
        }
    }
}