using E_commerce.Domain.Entities.Products;
using ECommerceApp.Application.Core;
using ECommerceApp.Application.DTos.ProductDTos;
using ECommerceApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Contracts
{
    public interface IProductService : IBaseService<ProductResponseDTO, ProductCreateDTO,  ProductUpdateDTO, Product>
    {
        Task<List<ProductWithCategory>> GetProductsByCategoryAsync(int categoryId);
    }
}
