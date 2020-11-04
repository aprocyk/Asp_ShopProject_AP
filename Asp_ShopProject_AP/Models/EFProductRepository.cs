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
    }
}
