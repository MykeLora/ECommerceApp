using E_commerce.Domain.Entities.Customers;
using ECommerceApp.Persistence.Base;
using ECommerceApp.Persistence.Context;
using ECommerceApp.Persistence.Interfaces.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Persistence.Repositories.Customers
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {

        private readonly ApplicationContext _context;
        public CustomerRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
    }
}
