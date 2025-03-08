using ECommerceApp.Application.Wrappers;
using ECommerceApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Core
{
    public interface IBaseService< TDResponse, TDSave, TDUpdate> 
    {
        Task<TDResponse> GetAll();
        Task<TDResponse> GetById(int id);
        Task<TDResponse> Save(TDSave dto);
        Task<TDResponse> Update(TDUpdate dto);
    }
}
