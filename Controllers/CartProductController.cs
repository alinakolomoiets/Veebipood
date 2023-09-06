using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veebipood.Data;
using Veebipood.Models;

namespace Veebipood.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CartProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CartProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public List<CartProduct> PostCartProduct([FromBody] CartProduct cartproduct)
        {
            _context.Product.Add(cartproduct.Prod);
            _context.SaveChanges();

            cartproduct.ProductId = cartproduct.Prod.Id;

            _context.CartProduct.Add(cartproduct);
            _context.SaveChanges();
            return _context.CartProduct.Include(b => b.Prod).ToList();
        }
        [HttpGet]
        public List<CartProduct> GetCartProduct()
        {
            var cartproduct = _context.CartProduct.Include(b => b.Prod).ToList();
            return cartproduct;
        }
        [HttpGet("{id}")]
        public ActionResult<CartProduct> GetCartProduct(int id)
        {
            var cartproduct = _context.CartProduct.Include(b => b.Prod).FirstOrDefault(b => b.Id == id);

            if (cartproduct == null)
            {
                return NotFound();
            }

            return cartproduct;
        }
        [HttpDelete("{id}")]
        public List<CartProduct> DeleteCartProduct(int id)
        {
            var cartproduct = _context.CartProduct.Include(b => b.Prod).FirstOrDefault(b => b.Id == id);

            if (cartproduct == null)
            {
                return _context.CartProduct.Include(b => b.Prod).ToList();
            }

            if (cartproduct.Prod != null)
            {
                _context.Product.Remove(cartproduct.Prod);
            }

            _context.CartProduct.Remove(cartproduct);
            _context.SaveChanges();
            return _context.CartProduct.Include(b => b.Prod).ToList();
        }
    }
}