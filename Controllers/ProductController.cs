﻿using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using Veebipood.Models;

namespace Veebipood.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static Product _product = new Product(1, "Koola", 1.5, true,4);

        // GET: toode
        [HttpGet]
        public Product GetToode()
        {
            return _product;
        }

        // GET: toode/suurenda-hinda
        [HttpGet("suurenda-hinda")]
        public Product SuurendaHinda()
        {
            _product.Price = _product.Price + 1;
            return _product;
        }
    }
}