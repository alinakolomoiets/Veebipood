using Microsoft.AspNetCore.Mvc;
using Veebipood.Data;
using Veebipood.Models;


namespace Veebipood.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PersonController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Person> GetPerson()
        {
            var person = _context.Person.ToList();
            return person;
        }

        [HttpPost]
        public List<Person> PostPerson([FromBody] Person person)
        {
            _context.Person.Add(person);
            _context.SaveChanges();
            return _context.Person.ToList();
        }

        [HttpDelete("delete")]
        public IActionResult DeletePerson(int id)
        {
            var person = _context.Person.Find(id);

            if (person == null)
            {
                return NotFound();
            }

            _context.Person.Remove(person);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<Person> GetPerson(int id)
        {
            var person = _context.Person.Find(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        [HttpPut("{id}")]
        public ActionResult<List<Person>> PutPerson(int id, [FromBody] Person updatedPerson)
        {
            var person = _context.Person.Find(id);

            if (person == null)
            {
                return NotFound();
            }

            person.FirstName = updatedPerson.FirstName;
            person.LastName = updatedPerson.LastName;

            _context.Person.Update(person);
            _context.SaveChanges();

            return Ok(_context.Person);
        }
    }
}