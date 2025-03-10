using BECommerceApp.Persistance.Base;
using E_commerce.Domain.Entities.Products;
using ECommerceApp.Domain.Common;
using ECommerceApp.Persistence.Context;
using ECommerceApp.Persistence.Interfaces.Products;
using ECommerceApp.Persistence.Models.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace ECommerceApp.Persistence.Repositories.Products
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(ApplicationContext context, ILogger<ProductRepository> logger ) : base(context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<ProductCategoryModel>> GetProductsByCategory(int categoryId)
        {
            List<ProductCategoryModel> querys = new List<ProductCategoryModel>();

            try
            {
                querys = await (from product in _context.Products
                                join category in _context.Categories on product.CategoryId equals category.Id
                                where product.CategoryId == categoryId
                                select new ProductCategoryModel()
                                {
                                    Id = product.Id,
                                    CategoryId = category.Id,
                                    CategoryName = category.Name,
                                    Name = product.Name,
                                    Description = product.Description,
                                    Price = product.Price,
                                    DiscountPercentage = product.DiscountPercentage,
                                    StockQuantity = product.StockQuantity,
                                    ImageUrl = product.ImageUrl,
                                    IsAvailable = product.IsActive
                                }).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting products by category: {ex.Message}");
            }

            return querys;
        } 

        public override Task<Product> AddAsync(Product entity)
        {
            return base.AddAsync(entity);
        }

    }

}
