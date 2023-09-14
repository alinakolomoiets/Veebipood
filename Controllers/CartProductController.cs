using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veebipood.Data;
using Veebipood.Models;

namespace Veebipood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CartProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<CartProduct> GetCartProduct()
        {
            var product = _context.CartProduct.ToList();
            return product;
        }

        [HttpPost]
        public List<CartProduct> PostProduct([FromBody] CartProduct product)
        {
            _context.CartProduct.Add(product);
            _context.SaveChanges();
            return _context.CartProduct.ToList();
        }

        [HttpDelete("{id}")]
        public List<CartProduct> DeleteCartProducts(int id)
        {
            var person = _context.CartProduct.Find(id);

            if (person == null)
            {
                return _context.CartProduct.ToList();
            }

            _context.CartProduct.Remove(person);
            _context.SaveChanges();
            return _context.CartProduct.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<CartProduct> GetCartProduct(int id)
        {
            var persons = _context.CartProduct.Find(id);

            if (persons == null)
            {
                return NotFound();
            }

            return persons;
        }

        [HttpPut("{id}")]
        public ActionResult<List<CartProduct>> PutProduct(int id, [FromBody] CartProduct updatedPerson)
        {
            var person = _context.CartProduct.Find(id);

            if (person == null)
            {
                return NotFound();
            }

            person.ProductId = updatedPerson.ProductId;
            person.Quantity = updatedPerson.Quantity;

            _context.CartProduct.Update(person);
            _context.SaveChanges();

            return Ok(_context.CartProduct);
        }
    }
}