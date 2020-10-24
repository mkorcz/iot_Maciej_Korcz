using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab1_Korcz.Rest.Context;
using Lab1_Korcz.Rest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Lab1_Korcz.Rest.Controllers
{
    [ApiController]
    [Route("api/people")]
    public class PeopleController : ControllerBase
    {
        private readonly AzureDbContext db;
        public Person people;
        public PeopleController(AzureDbContext db)
        {
            this.db = db;
        }

        public AzureDbContext Db { get; }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(db.People.ToList());
        }


        [HttpGet("find/{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var person = db.People.FirstOrDefault(w => w.PersonId == id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost("add")]
        public IActionResult POST()
        {
            Person person = new Person
            {
                FirstName = Request.Form["firstName"],
                LastName = Request.Form["lastName"]
            };
            db.People.Add(person);
            db.SaveChanges();
            return Ok(person);
        }

        [HttpGet("delete/{test}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var person = db.People.FirstOrDefault(w => w.PersonId == id);
            if (person == null)
            {
                return NotFound();
            }
            db.People.Remove(person);
            db.SaveChanges();
            return Ok("Deleted");
        }
        [HttpPut("update/{id}")]
        public IActionResult Update([FromRoute] int id)
        {
            var person = db.People.FirstOrDefault(w => w.PersonId == id);
            if (person == null)
            {
                return NotFound();
            }
            person.FirstName = Request.Form["firstName"];
            person.LastName = Request.Form["lastName"];
            db.People.Update(person);
            db.SaveChanges();
            return Ok(person);

        }
    }
}
