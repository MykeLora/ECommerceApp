using ECommerceApp.Application.Wrappers;
using ECommerceApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Core
{
    public interface IBaseService< TDResponse, TDSave, TDUpdate> where 
    {
        Task<IEnumerable<TDResponse>> GetAllAsync();
        Task<TDResponse> GetByIdAsync(int id);
        Task<TDResponse> SaveAsync(TDSave dto);
        Task<TDResponse> UpdateAsync(TDUpdate dto);
    }
}
