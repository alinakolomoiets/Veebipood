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
        [HttpPost]
        public List<Product> PostProduct([FromBody] Product product)
        {
            _context.Category.Add(product.Cat);
            _context.SaveChanges();

            product.CategoryId = product.Cat.Id;

            _context.Product.Add(product);
            _context.SaveChanges();
            return _context.Product.Include(a => a.Cat).ToList();
        }
        [HttpGet]
        public List<Product> GetProduct()
        {
            var product = _context.Product.Include(a => a.Cat).ToList();
            return product;
        }
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _context.Product.Include(a => a.Cat).FirstOrDefault(a => a.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }
        [HttpDelete("{id}")]
        public List<Product> DeleteProduct(int id)
        {
            var product = _context.Product.Include(a => a.Cat).FirstOrDefault(a => a.Id == id);

            if (product == null)
            {
                return _context.Product.Include(a => a.Cat).ToList();
            }

            if (product.Cat != null)
            {
                _context.Category.Remove(product.Cat);
            }

            _context.Product.Remove(product);
            _context.SaveChanges();
            return _context.Product.Include(a => a.Cat).ToList();
        }
    }
}