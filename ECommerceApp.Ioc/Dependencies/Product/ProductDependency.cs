using ECommerceApp.Application.Contracts;
using ECommerceApp.Application.Services.Products;
using ECommerceApp.Persistence.Interfaces.Products;
using ECommerceApp.Persistence.Repositories.Products;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Ioc.Dependencies.Product
{
    public static class ProductDependency
    {
        public static void AddProductDependencies(this IServiceCollection services)
        {

            // AddProductDependencies

            #region "Repositories"
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            #endregion

            #region "Services"
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICategoryService, CategoryService>();
            #endregion
        }
    }
}
