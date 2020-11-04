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
        private readonly IProductRepository repository;
        public IActionResult Index()
        {
            return View();
        }
        public ViewResult List() => View(repository.Products);

    }
}
