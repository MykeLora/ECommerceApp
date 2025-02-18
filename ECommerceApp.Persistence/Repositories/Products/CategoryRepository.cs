using E_commerce.Domain.Entities.Products;
using ECommerceApp.Persistence.Base;
using ECommerceApp.Persistence.Context;
using ECommerceApp.Persistence.Interfaces.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Persistence.Repositories.Products
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {

        public CategoryRepository(ApplicationContext context) : base(context)
        {

        }




    }
}
