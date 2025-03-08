//using ECommerceApp.Persistence.Interfaces.Customers;
//using ECommerceApp.Persistence.Repositories.Customers;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace ECommerceApp.Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CustomersController : ControllerBase
//    {
//        private readonly ICustomerRepository _customerRepository;

//        public CustomersController(ICustomerRepository customer)
//        {
//            _customerRepository = customer;
//        }

//        [HttpGet("Get-All-Customers")]
//        public async Task<IActionResult> GetAllCustomer()
//        {
//            var customers = await _customerRepository.GetAllAsync();
//            return Ok(customers);
//        }
//    }
//}
