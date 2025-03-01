using BECommerceApp.Persistance.Base;
using E_commerce.Domain.Entities.Products;
using ECommerceApp.Persistence.Context;
using ECommerceApp.Persistence.Interfaces.Products;

namespace ECommerceApp.Persistence.Repositories.Products
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationContext _context;

        public CategoryRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }


    }
}
