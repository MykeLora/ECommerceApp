using E_commerce.Domain.Entities.Products;
using ECommerceApp.Api.Models;
using ECommerceApp.Application.DTos.ProductDTos;
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

        [HttpGet("GetProductsByCategory/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategory(int categoryId)
        {
            var products = await _productRepository.GetProductsByCategory(categoryId);
            return Ok(products);
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> Post([FromBody] ProductCreateDTO createDTO)
        {
            if (createDTO == null)
                return BadRequest("El objeto no puede ser nulo.");

            var product = new Product
            {
                Name = createDTO.Name,
                Price = createDTO.Price,
                Description = createDTO.Description,
                DiscountPercentage = createDTO.DiscountPercentage,
                StockQuantity = createDTO.StockQuantity,
                ImageUrl = createDTO.ImageUrl,
                CategoryId = createDTO.CategoryId
            };

            // Guardar el producto en la base de datos
            var createdProduct = await _productRepository.AddAsync(product);

            // Devolver el objeto creado con su ID
            return Ok("Product created");
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductUpdateDTO updateDTO)
        {
            if (updateDTO == null)
                return BadRequest("El objeto no puede ser nulo.");

            // Buscar el producto en la base de datos
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null)
                return NotFound($"No se encontró un producto con el ID {id}.");

            // Mapear los cambios del DTO al objeto existente
            existingProduct.Id = updateDTO.Id;
            existingProduct.Name = updateDTO.Name;
            existingProduct.Price = updateDTO.Price;
            existingProduct.Description = updateDTO.Description;
            existingProduct.DiscountPercentage = updateDTO.DiscountPercentage;
            existingProduct.StockQuantity = updateDTO.StockQuantity;
            existingProduct.ImageUrl = updateDTO.ImageUrl;
            existingProduct.CategoryId = updateDTO.CategoryId;


            // Actualizar el producto
            var updatedProduct = await _productRepository.UpdateAsync(existingProduct);

            return Ok(updatedProduct);
        }


        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var entity = await _productRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            await _productRepository.RemoveAsync(entity);

            return Ok();
        }

    }
}

