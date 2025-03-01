using ECommerceApp.Application.Services;
using ECommerceApp.Application.Wrappers;
using ECommerceApp.DTOs.CategoryDTOs;
using ECommerceApp.Persistence.Interfaces.Products;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerceApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryservice;
        

        public CategoryController(CategoryService category)
        {
            _categoryservice = category;
        }


        
        [HttpGet("Get-All-Categorie")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryservice.GetAllAsync();

            if (categories == null)
            {
                return BadRequest();
            }
            return Ok(categories);
        }

        //[HttpGet("Get-Category-ById/{id}")]
        //public async Task<IActionResult> GetCategoryById(int id)
        //{
        //    //var category = await _categoryRepository.GetByIdAsync(id);
        //    //return Ok(category);
        //}

        //// Creates a new category.
        //[HttpPost("CreateCategory")]
        //public async Task<ActionResult<Response<CategoryResponseDTO>>> CreateCategory([FromBody] CategoryCreateDTO categoryDto)
        //{
        //    var response = await _categoryservice.CreateCategoryAsync(categoryDto);
        //    if (response.StatusCode != 200)
        //    {
        //        return StatusCode(response.StatusCode, response);
        //    }
        //    return Ok(response);
        //}

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
