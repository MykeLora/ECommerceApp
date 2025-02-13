using E_commerce.Domain.Entities.Products;
using ECommerceApp.Application.Interfaces;
using ECommerceApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Persistence.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<Result> GetProductsByCategory(int categoryId);
    }
}
