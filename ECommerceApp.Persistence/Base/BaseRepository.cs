using ECommerceApp.Application.Interfaces;
using ECommerceApp.Domain.Common;
using ECommerceApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Persistence.Base
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class 
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public  async Task<Result> AddAsync(TEntity entity)
        {
            Result result = new Result();

            try
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error saving the entity.";
            }

            return result;
        }

        public async Task<Result> DeleteAsync(int id)
        {
            
            Result result = new Result();

            try
            {
                var entity = await _dbSet.FindAsync(id);
                if (entity == null)
                {
                    result.Success = false;
                    result.Message = $"Entity not found.";
                    return result;
                }
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error deleting the entity.";
            }
            return result;
        }

        public Task<bool> Exists(Expression<Func<TEntity, bool>> filter)
        {
            Result result = new Result();

            try
            {
                var entity = _dbSet.Where(filter).FirstOrDefault();
                if (entity == null)
                {
                    return Task.FromResult(false);
                }
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }

        public Task<Result> FindAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            Result result = new Result();

            try
            {
                var entities = _dbSet.Where(filter).ToList();
                result.Data = entities;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error finding the entities.";
            }
            return Task.FromResult(result);
        }

        public Task<Result> GetAllAsync()
        {
            Result result = new Result();

            try
            {
                var entities = _dbSet.ToList();
                result.Data = entities;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error getting the entities.";
            }

            return Task.FromResult(result);
        }

        public Task<Result> GetByIdAsync(int id)
        {
            Result result = new Result();

            try
            {
                var entity = _dbSet.Find(id);
                if (entity == null)
                {
                    result.Success = false;
                    result.Message = $"Entity not found.";
                    return Task.FromResult(result);
                }
                result.Data = entity;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error getting the entity.";
            }

            return Task.FromResult(result);
        }

        public async Task<Result> UpdateAsync(TEntity entity)
        {
            Result result = new Result();

            try
            {
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error updating the entity.";
            }
            return result;
        }
    }
  
}
