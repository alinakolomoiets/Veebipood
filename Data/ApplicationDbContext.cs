using Microsoft.EntityFrameworkCore;
using Veebipood.Models;

namespace Veebipood.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<CartProduct> CartProduct { get; set; }
        public DbSet<Order> Order { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}

