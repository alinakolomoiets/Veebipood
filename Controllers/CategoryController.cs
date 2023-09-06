using Microsoft.AspNetCore.Mvc;
using Veebipood.Data;
using Veebipood.Migrations;
using Veebipood.Models;


namespace Veebipood.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Category> GetCategory()
        {
            var category = _context.Category.ToList();
            return category;
        }

        [HttpPost]
        public List<Category> PostCategory([FromBody] Category category)
        {
            _context.Category.Add(category);
            _context.SaveChanges();
            return _context.Category.ToList();
        }

        [HttpDelete("delete")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _context.Category.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            _context.Category.Remove(category);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<Category> GetCategory(int id)
        {
            var category = _context.Category.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        [HttpPut("{id}")]
        public ActionResult<List<Category>> PutCategory(int id, [FromBody] Category updatedCategory)
        {
            var category = _context.Category.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            category.Name = updatedCategory.Name;

            _context.Category.Update(category);
            _context.SaveChanges();

            return Ok(_context.Person);
        }
    }
}