using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp_ShopProject_AP.Models
{
    public class EFProductRepository : IProductRepository
    {
        private readonly AppDbContext ctx;

        public EFProductRepository(AppDbContext ctx) 
        {
            this.ctx = ctx;
        }

        public IQueryable<Product> Products => ctx.Products;

        public void SaveProduct(Product product)
        {
            if(product.Id == 0)
            {
                ctx.Products.Add(product);
            }
            else
            {
                Product dbEntry = ctx.Products
                    .FirstOrDefault(p => p.Id == product.Id);
                if(dbEntry != null)
                {
                    dbEntry.ProductName = product.ProductName;
                    dbEntry.ProductDescription = product.ProductDescription;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                }
            }
            ctx.SaveChanges();
        }

        public Product DeleteProduct(int productID)
        {
            Product dbEntry = ctx.Products
                .FirstOrDefault(p => p.Id == productID);
            if(dbEntry != null)
            {
                ctx.Products.Remove(dbEntry);
                ctx.SaveChanges();
            }
            return dbEntry;
        }
    }
}
