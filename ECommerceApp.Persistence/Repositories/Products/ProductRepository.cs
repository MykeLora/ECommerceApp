using E_commerce.Domain.Entities.Products;
using ECommerceApp.Domain.Common;
using ECommerceApp.Persistence.Base;
using ECommerceApp.Persistence.Context;
using ECommerceApp.Persistence.Interfaces.Products;
using ECommerceApp.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Persistence.Repositories.Products
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly ApplicationContext _context;

        public ProductRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Result> GetProductsByCategory(int categoryId)
        {
            Result result = new Result();

            ProductCategoryModel prodCat = new ProductCategoryModel();

            try
            {
                var querys = await (from product in _context.Products
                                    join category in _context.Categories on product.CategoryId equals prodCat.Id
                                    where product.CategoryId == categoryId
                                    select new ProductCategoryModel()
                                    {
                                        CategoryId = prodCat.Id,
                                        Name = prodCat.Name,
                                        Description = prodCat.Description,
                                        Price = prodCat.Price,
                                        DiscountPercentage = prodCat.DiscountPercentage,
                                        StockQuantity = prodCat.StockQuantity,
                                        ImageUrl = prodCat.ImageUrl,
                                        IsAvailable = prodCat.IsAvailable

                                    }).ToListAsync();

                result.Data = querys;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error getting products by category.";
            }
            return result;
        }


    }

}
