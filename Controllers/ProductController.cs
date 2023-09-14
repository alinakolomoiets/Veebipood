using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veebipood.Data;
using Veebipood.Models;

namespace Veebipood.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Product> GetProducts()
        {
            var product = _context.Product.ToList();
            return product;
        }

        [HttpPost]
        public List<Product> PostProducts([FromBody] Product product)
        {
            _context.Product.Add(product);
            _context.SaveChanges();
            return _context.Product.ToList();
        }

        [HttpDelete("{id}")]
        public List<Product> DeleteProducts(int id)
        {
            var person = _context.Product.Find(id);

            if (person == null)
            {
                return _context.Product.ToList();
            }

            _context.Product.Remove(person);
            _context.SaveChanges();
            return _context.Product.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProducts(int id)
        {
            var persons = _context.Product.Find(id);

            if (persons == null)
            {
                return NotFound();
            }

            return persons;
        }

        [HttpPut("{id}")]
        public ActionResult<List<Product>> PutProducts(int id, [FromBody] Product updatedPersons)
        {
            var persons = _context.Product.Find(id);

            if (persons == null)
            {
                return NotFound();
            }

            persons.Name = updatedPersons.Name;
            persons.Price = updatedPersons.Price;

            _context.Product.Update(persons);
            _context.SaveChanges();

            return Ok(_context.Product);
        }
    }
}