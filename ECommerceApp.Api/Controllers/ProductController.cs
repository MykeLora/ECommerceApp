using E_commerce.Domain.Entities.Products;
using ECommerceApp.Api.Models;
using ECommerceApp.Persistence.Interfaces.Products;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerceApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("GetAllProducts")]

        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productRepository.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("GetProductById/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return Ok(product);
        }

        // POST api/<ValuesController>
        [HttpPost("Create-Product")]
      public async Task<IActionResult> CreateProduct(ProductModel product)
      {
            Product model = new Product();

            model.Id = product.Id;
            model.Name = product.Name;
            model.Description = product.Description;
            model.Price = product.Price;
            model.CategoryId = product.CategoryId;
            model.StockQuantity = product.StockQuantity;
            model.IsAvailable = product.IsAvailable;
            model.ImageUrl = product.ImageUrl;

            var products =  await _productRepository.AddAsync(model);
            return Ok(products);

      }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
