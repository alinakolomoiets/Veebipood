﻿namespace Veebipood.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public bool Active { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public ICollection<Category> Category { get; set; }
        public Product(int id, string name, double price, bool active,int stock)
        {
            Id = id;
            Name = name;
            Price = price;
            Active = active;
            Stock = stock;
        }
    }
}
