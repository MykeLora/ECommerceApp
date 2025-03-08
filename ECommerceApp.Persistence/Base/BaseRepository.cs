using ECommerceApp.Application.Interfaces;
using ECommerceApp.Domain.Common;
using ECommerceApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BECommerceApp.Persistance.Base
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationContext _context;
        private DbSet<TEntity> _entities;
        public BaseRepository(ApplicationContext context)
        {

            _context = context;
            _entities = _context.Set<TEntity>();
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
             _entities.AddAsync(entity);
             await _context.SaveChangesAsync();
             return entity;
        }

        public virtual async Task<bool> Exists(Expression<Func<TEntity, bool>> filter)
        {
            return await _entities.AnyAsync(filter);
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            var entities = await _entities.ToListAsync();
            return entities;
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            var search = await _entities.FindAsync(id);
            if(search == null) 
            { 
                throw new Exception("Don't exixt any register with this Id"); 
            }
            return search;
        }

        public virtual async Task<TEntity> RemoveAsync(TEntity entity)
        {
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
             _entities.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}