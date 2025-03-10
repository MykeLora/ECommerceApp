using ECommerceApp.Application.Wrappers;
using ECommerceApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Core
{
    public interface IBaseService<TDResponse, TDSave, TDUpdate, TEntity>
        where TDResponse : class
        where TDSave : class
        where TDUpdate : class
        where TEntity : class
    {
    
        Task<List<TDResponse>> GetAllAsync();
        Task<TDResponse> GetByIdAsync(int id);
        Task<TDResponse> SaveAsync(TDSave dto);
        Task UpdateAsync(TDUpdate dto);
        Task DeleteAsync(int id);
    }

}
