using E_commerce.Domain.Entities.Customers;
using ECommerceApp.Application.Interfaces;
using ECommerceApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Persistence.Interfaces.Customers
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {

        Task RegisterCustomerAsync();
        Task LoginAsync();
    }
}
