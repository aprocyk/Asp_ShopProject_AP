using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp_ShopProject_AP.Models;
using Microsoft.AspNetCore.Mvc;

namespace Asp_ShopProject_AP.Controllers
{
    
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public ViewResult ListAll() => View(productRepository.Products);
        public ViewResult List(string category) => View(productRepository.Products.Where(p => p.Category == category));
        public ViewResult GetById(int id) => View(productRepository.Products.Single(p => p.Id == id));
        public IActionResult Index()
        {
            return View();
        }
        

    }
}
