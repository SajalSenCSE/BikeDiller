using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BikeDiller.Repositories.Abstraction
{
    public interface IBaseRepository<T> where T:class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<bool> AddNew(T entity);
        Task<bool> UpdateEntity(T entity);
        Task<bool> DeleteEntity(T entity);
    }
}
