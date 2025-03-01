using ECommerceApp.Application.Core;
using ECommerceApp.Application.Responses.Configuration.Category;
using ECommerceApp.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Contracts
{
    public interface ICategoryService : IBaseService<CategoryResponse,CategoryCreateDTO,CategoryUpdateDTO>
    { 
    }
}
