using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp_ShopProject_AP.Models
{
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products =>
            new List<Product>
            {
                new Product{Id=1,ProductName="a",ProductDescription="b",Price=1,Category="K"},
                new Product{Id=2,ProductName="ab",ProductDescription="bc",Price=1,Category="KK"}
            }.AsQueryable<Product>();
            
    }      
            
        
    
}
