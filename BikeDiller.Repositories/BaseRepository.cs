using BikeDiller.Repositories.Abstraction;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BikeDiller.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        DbContext _db;
        public BaseRepository(DbContext db)
        {
            _db = db;
        }

        
        private DbSet<T> Table
        {
            get
            {
                return _db.Set<T>();
            }
        }

        private async Task<bool> Save()
        {
            return await _db.SaveChangesAsync() > 0;
        }
        public virtual async Task<bool> AddNew(T entity)
        {
            _db.Add(entity);
            return await Save();
        }

        public virtual async Task<bool> DeleteEntity(T entity)
        {
            _db.Remove(entity);
            return await Save();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await Table.ToListAsync();
        }

        public abstract Task<T> GetById(int id);
       

        public virtual async Task<bool> UpdateEntity(T entity)
        {
            _db.Update(entity);
            return await Save();
        }
    }
}
