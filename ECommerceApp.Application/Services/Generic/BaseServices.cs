using AutoMapper;
using ECommerceApp.Application.DTos.ProductDTos;
using ECommerceApp.Application.Interfaces;
using ECommerceApp.Application.Wrappers;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Core
{
    public abstract class BaseService<TDResponse, TDSave, TDUpdate, TEntity> 
        : IBaseService<TDResponse, TDSave, TDUpdate, TEntity>
        where TDResponse : class
        where TDSave : class
        where TDUpdate : class
        where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public BaseService(IBaseRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        public virtual async Task<List<TDResponse>> GetAllAsync()
        {

            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<TDResponse>>(entities);
        }


        public virtual async Task<TDResponse> GetByIdAsync(int id)
        {

            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<TDResponse>(entity);

        }

        public virtual async Task<TDResponse> SaveAsync(TDSave dto)
        {

            var entity = _mapper.Map<TEntity>(dto);
            var savedEntity = await _repository.AddAsync(entity);
            return _mapper.Map<TDResponse>(savedEntity);

        }

        public virtual async Task UpdateAsync(TDUpdate dto)
        {

            var entity = _mapper.Map<TEntity>(dto);
            await _repository.UpdateAsync(entity);

        }

        public virtual async Task DeleteAsync(int id)
        {

            var entity = await _repository.GetByIdAsync(id);
            await _repository.RemoveAsync(entity);

        }

   
    }
}
