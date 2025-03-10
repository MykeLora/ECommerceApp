using E_commerce.Domain.Entities.Products;
using ECommerceApp.Application.Core;
using ECommerceApp.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Contracts
{
    public interface ICategoryService : IBaseService<CategoryResponseDTO, CategoryCreateDTO, CategoryUpdateDTO, Category>
    {
    }
}
