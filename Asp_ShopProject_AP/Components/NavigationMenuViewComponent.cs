using Asp_ShopProject_AP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp_ShopProject_AP.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private readonly IProductRepository _productRepository;

        public NavigationMenuViewComponent(IProductRepository productRepository) 
        {
            _productRepository = productRepository;
        }

        public IViewComponentResult Invoke() //Wywołana kiedy następuje odwołanie do tego komponentu.
        {
            return View(_productRepository.Products.Select(x => x.Category).Distinct().OrderBy(x => x)); // zwracamy unikalne kategorie
        }
    }
}
