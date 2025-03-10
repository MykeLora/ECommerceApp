using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ECommerceApp.Domain.Common;

namespace ECommerceApp.Application.Interfaces
{


    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> GetAllWithInclude(List<string> propierties);
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> RemoveAsync(TEntity entity);
        Task<bool> Exists(Expression<Func<TEntity, bool>> filter);
    }
}