using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ECommerceApp.Domain.Common;

namespace ECommerceApp.Application.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<Result> GetAllAsync();
        Task<Result> GetByIdAsync(int id);
        Task<Result> AddAsync(TEntity entity);
        Task<Result> UpdateAsync(TEntity entity);
        Task<Result> DeleteAsync(int id);
        Task<Result> FindAllAsync(Expression<Func<TEntity, bool>> filter);
        Task<bool> Exists(Expression<Func<TEntity, bool>> filter);
    }
}
