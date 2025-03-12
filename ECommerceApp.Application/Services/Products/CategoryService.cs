using AutoMapper;
using E_commerce.Domain.Entities.Products;
using ECommerceApp.Application.Contracts;
using ECommerceApp.Application.Core;
using ECommerceApp.Application.Interfaces;
using ECommerceApp.DTOs.CategoryDTOs;
using ECommerceApp.Persistence.Interfaces.Products;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Services.Products
{
    public class CategoryService : BaseService<CategoryResponseDTO, CategoryCreateDTO, CategoryUpdateDTO, Category>, ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, ILogger<CategoryService> logger) : base(categoryRepository, mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _logger = logger;

        }

        public override async Task<List<CategoryResponseDTO>> GetAllAsync()
        {
            try
            {
                var categories = await _categoryRepository.GetAllAsync();
                if (categories == null || !categories.Any())
                {
                    _logger.LogWarning("No categories found");
                    return new List<CategoryResponseDTO>(); 
                }
                return _mapper.Map<List<CategoryResponseDTO>>(categories);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving categories");
                return new List<CategoryResponseDTO>(); 
            }
        }

        public override async Task<CategoryResponseDTO> GetByIdAsync(int id)
        {
            try
            {
                var category = await _categoryRepository.GetByIdAsync(id);

                if(category is null)
                {
                    _logger.LogWarning($"Category with id {id} not found");
                    return null;
                }
                return _mapper.Map<CategoryResponseDTO>(category);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving category");
                return null;
            }
        }

        public override async Task<CategoryResponseDTO> SaveAsync(CategoryCreateDTO dto)
        {
            try
            {
                var category = _mapper.Map<Category>(dto);
                var savedCategory = await  _categoryRepository.AddAsync(category);

                return _mapper.Map<CategoryResponseDTO>(savedCategory);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving category");
                throw;
            }
        }

        public override Task UpdateAsync(CategoryUpdateDTO dto)
        {
            try
            {
                var category = _mapper.Map<Category>(dto);
                return _categoryRepository.UpdateAsync(category);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating category");
                throw;

            }

        }

        public override async Task DeleteAsync(int id)
        {
            try
            {
                var existingCategory = await _categoryRepository.GetByIdAsync(id);

                if (existingCategory is null)
                {
                    _logger.LogWarning($"Category with id {id} not found");
                    return;
                }
                existingCategory.IsActive = false;
                await _categoryRepository.RemoveAsync(existingCategory);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting category");
                throw;
            }
    
        }
    }
}
