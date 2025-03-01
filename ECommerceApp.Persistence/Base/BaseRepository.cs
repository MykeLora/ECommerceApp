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

        public virtual async Task<bool> Exists(Expression<Func<TEntity, bool>> filter)
        {
            return await _entities.AnyAsync(filter);
        }

        public virtual async Task<Result> GetAllAsync()
        {
            Result result = new Result();

            try
            {
                var datos = await _entities.ToListAsync();
                result.Data = datos;
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Ocurrió un error {ex.Message} obteniendo los datos.";
            }

            return result;
        }

        public virtual async Task<Result> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            Result result = new Result();

            try
            {
                var datos = await _entities.Where(filter).ToListAsync();
                result.Data = datos;
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Ocurrió un error {ex.Message} obteniendo los datos.";
            }

            return result;

        }

        public virtual async Task<Result> GetByIdAsync(int Id)
        {
            Result result = new Result();
            try
            {
                var entity = await _entities.FindAsync(Id);
                result.Data = entity;
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Ocurrió un error {ex.Message} obteniendo la entidad.";
            }
            return result;
        }

        public async virtual Task<Result> DeleteAsync(TEntity entity)
        {
            Result result = new Result();

            try
            {
                _entities.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error {ex.Message} removiendo la entidad.";

            }

            return result;
        }

        public virtual async Task<Result> AddAsync(TEntity entity)
        {
            Result result = new Result();

            try
            {
                _entities.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error {ex.Message} guardando la entidad.";

            }

            return result;
        }

        public virtual async Task<Result> UpdateAsync(TEntity entity)
        {
            Result result = new Result();

            try
            {
                _entities.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error {ex.Message} actualizando la entidad.";

            }

            return result;
        }
    }
}