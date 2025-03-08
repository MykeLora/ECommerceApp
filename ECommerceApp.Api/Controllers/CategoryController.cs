using E_commerce.Domain.Entities.Products;
using ECommerceApp.Application.Contracts;
using ECommerceApp.DTOs.CategoryDTOs;
using ECommerceApp.Persistence.Interfaces.Products;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("Get-All-Categories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAll();
            return Ok(categories);
        }

        


    }
}
