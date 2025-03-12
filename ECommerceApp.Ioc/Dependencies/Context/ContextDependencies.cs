using ECommerceApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Ioc.Dependencies.Context
{
    public static class ContextDependencies
    {

        public static void AddContextDependencies(this IServiceCollection services, string connectionString )
        {
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

        }
    }
}
