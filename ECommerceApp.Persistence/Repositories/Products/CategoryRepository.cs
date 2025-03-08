using BECommerceApp.Persistance.Base;
using E_commerce.Domain.Entities.Products;
using ECommerceApp.Domain.Common;
using ECommerceApp.Persistence.Context;
using ECommerceApp.Persistence.Interfaces.Products;
using ECommerceApp.Persistence.Models.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace ECommerceApp.Persistence.Repositories.Products
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<CategoryRepository> _logger;

        public CategoryRepository(ApplicationContext context, ILogger<CategoryRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

       
      
    }
}
