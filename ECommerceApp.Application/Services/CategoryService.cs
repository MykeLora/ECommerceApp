using Azure;
using E_commerce.Domain.Entities.Products;
using ECommerceApp.Application.Contracts;
using ECommerceApp.Application.Responses.Configuration.Category;
using ECommerceApp.Application.Wrappers;
using ECommerceApp.Domain.Common;
using ECommerceApp.DTOs.CategoryDTOs;
using ECommerceApp.Persistence.Context;
using ECommerceApp.Persistence.Interfaces.Products;
using ECommerceApp.Persistence.Repositories.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(CategoryRepository categoryRepository,
                               ILogger<CategoryService> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<CategoryResponse>> GetAllAsync()
        {
            CategoryResponse categoryResponse = new CategoryResponse();

            try
            {
                var result = await _categoryRepository.GetAllAsync();


                if (!result.Success)
                {
                    categoryResponse.Message = result.Message;
                    categoryResponse.IsSuccess = result.Success;
                    return (IEnumerable<CategoryResponse>)categoryResponse;
                }

                


                categoryResponse.Data = result.Data;
                categoryResponse.IsSuccess = true;
                categoryResponse.Message = "Categorias encontradas.";
            }
            catch (Exception ex)
            {
                categoryResponse.IsSuccess = false;
                categoryResponse.Message = ex.Message;
                _logger.LogError(ex, ex.Message);
            }
            return categoryResponse.Data;
        }

        public Task<CategoryResponse> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryResponse> SaveAsync(CategoryCreateDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryResponse> UpdateAsync(CategoryUpdateDTO dto)
        {
            throw new NotImplementedException();
        }
    }

}
