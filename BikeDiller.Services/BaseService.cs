using BikeDiller.Repositories.Abstraction;
using BikeDiller.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BikeDiller.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        IBaseRepository<T> _baseRepository;

        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public virtual async Task<bool> AddNew(T entity)
        {
            return await _baseRepository.AddNew(entity);
        }

        public virtual async Task<bool> DeleteEntity(T entity)
        {
            return await _baseRepository.DeleteEntity(entity);
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _baseRepository.GetAll();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await _baseRepository.GetById(id); 
        }

        public virtual async Task<bool> UpdateEntity(T entity)
        {
            return await _baseRepository.UpdateEntity(entity);
        }
    }
}
