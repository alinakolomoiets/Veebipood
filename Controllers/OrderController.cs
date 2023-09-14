using Microsoft.AspNetCore.Mvc;
using System;
using Veebipood.Data;
using Veebipood.Models;

namespace Veebipood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Order> GetOrder()
        {
            var product = _context.Order.ToList();
            return product;
        }

        [HttpPost]
        public List<Order> PostOrders([FromBody] Order product)
        {
            _context.Order.Add(product);
            _context.SaveChanges();
            return _context.Order.ToList();
        }

        [HttpDelete("{id}")]
        public List<Order> DeleteOrders(int id)
        {
            var person = _context.Order.Find(id);

            if (person == null)
            {
                return _context.Order.ToList();
            }

            _context.Order.Remove(person);
            _context.SaveChanges();
            return _context.Order.ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrders(int id)
        {
            var person = _context.Order.Find(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        [HttpPut("{id}")]
        public ActionResult<List<Order>> PutOrders(int id, [FromBody] Order updatedPerson)
        {
            var person = _context.Order.Find(id);

            if (person == null)
            {
                return NotFound();
            }

            person.Person = updatedPerson.Person;
            person.created = updatedPerson.created;

            _context.Order.Update(person);
            _context.SaveChanges();

            return Ok(_context.Order);
        }
    }
}
