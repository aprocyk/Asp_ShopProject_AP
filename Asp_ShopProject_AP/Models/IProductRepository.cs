using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp_ShopProject_AP.Models
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}
