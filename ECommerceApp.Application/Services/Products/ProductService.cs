using AutoMapper;
using E_commerce.Domain.Entities.Products;
using ECommerceApp.Application.Contracts;
using ECommerceApp.Application.Core;
using ECommerceApp.Application.DTos.ProductDTos;
using ECommerceApp.Application.Wrappers;
using ECommerceApp.Persistence.Interfaces.Products;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Services.Products
{
    public class ProductService : BaseService<ProductResponseDTO, ProductCreateDTO, ProductUpdateDTO, Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductService> _logger;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, ILogger<ProductService> logger, IMapper mapper) : base(productRepository, mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;

        }

        public override async Task<List<ProductResponseDTO>> GetAllAsync()
        {
            try
            {
                var products = await _productRepository.GetAllAsync();

                if (products == null || !products.Any())
                {
                    _logger.LogWarning("No products found");
                    return new List<ProductResponseDTO>(); // Devuelve una lista vacía en vez de null
                }

                return _mapper.Map<List<ProductResponseDTO>>(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving products");
                return new List<ProductResponseDTO>(); // Devuelve una lista vacía en caso de error
            }
        }

        public override async Task<ProductResponseDTO> GetByIdAsync(int id)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(id);

                if (product is null)
                {
                    _logger.LogWarning($"Product with id {id} not found");
                    return null; // Se retorna null si el producto no existe
                }

                return _mapper.Map<ProductResponseDTO>(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving product with id {id}");
                return null; // Se maneja la excepción retornando null
            }
        }
        public async Task<List<ProductWithCategory>> GetProductsByCategoryAsync(int categoryId)
        {
            try
            {
                var productsWithCategory = await _productRepository.GetProductsByCategory(categoryId);

                if (productsWithCategory == null || !productsWithCategory.Any())
                {
                    _logger.LogWarning($"No products found for category with id {categoryId}");
                    return new List<ProductWithCategory>(); // Retorna una lista vacía en lugar de null
                }

                return _mapper.Map<List<ProductWithCategory>>(productsWithCategory);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving products for category with id {categoryId}");
                return new List<ProductWithCategory>(); // Retorna lista vacía en caso de error
            }
        }

        public override async Task<ProductResponseDTO> SaveAsync(ProductCreateDTO dto)

        {
            try
            {
                var product = _mapper.Map<Product>(dto);
                var savedProduct = await _productRepository.AddAsync(product);

                return _mapper.Map<ProductResponseDTO>(savedProduct);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while saving product");
                throw;
            }
        }

        public override Task UpdateAsync(ProductUpdateDTO dto)
        {
            try
            {

                var product = _mapper.Map<Product>(dto);
                return _productRepository.UpdateAsync(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating product");
                throw;
            }

        }

        public override async Task DeleteAsync(int id)
        {
            try
            {
                var existingProduct = await _productRepository.GetByIdAsync(id);

                if (existingProduct == null)
                {
                    _logger.LogWarning($"Product with id {id} not found");
                    return; 

                }
                existingProduct.IsActive = false;
                await _productRepository.RemoveAsync(existingProduct);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting product");
                throw;
            }

        }

        public async Task<ProductStatusUpdateDTO> UpdateStatus(int id, bool status)
        {
            try
            {
                var existingProduct = await _productRepository.GetByIdAsync(id);

                if(existingProduct == null)
                {
                    _logger.LogWarning($"Product with id {id} not found");
                    return null;
                }

                existingProduct.IsActive = status;
                await _productRepository.UpdateAsync(existingProduct);

                return _mapper.Map<ProductStatusUpdateDTO>(existingProduct);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating product status");
                throw;
            }
        }
    }
}