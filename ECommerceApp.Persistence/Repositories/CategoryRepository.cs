using E_commerce.Domain.Entities.Products;
using ECommerceApp.Persistence.Base;
using ECommerceApp.Persistence.Context;
using ECommerceApp.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Persistence.Repositories
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
