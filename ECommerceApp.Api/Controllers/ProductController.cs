using AutoMapper;
using E_commerce.Domain.Entities.Products;
using ECommerceApp.Api.Models;
using ECommerceApp.Application.Contracts;
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

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;

        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _productService.GetAllAsync();

            if(result == null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpGet("GetProductById/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var result = await _productService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpGet("GetProductsByCategory/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategory(int categoryId)
        {
            var result = await _productService.GetProductsByCategoryAsync(categoryId);
            if (result == null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductCreateDTO dto)
        {

            var result = await _productService.SaveAsync(dto);
            return Ok(result);
        }

        [HttpPut("UpdateStatus/{id}/{status}")]
        public async Task<IActionResult> UpdateStatus(int id, bool status)
        {
            var result = await _productService.UpdateStatus(id, status);
            return Ok("Status Update successfuly");
        }


        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductUpdateDTO product)
        { 
            await _productService.UpdateAsync(product);
            return Ok("Product updated succefuly");
        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteAsync(id);
            return Ok("Product deleted succesfuly");
        }

    }
}

