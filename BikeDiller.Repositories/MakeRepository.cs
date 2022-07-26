using BikeDiller.DataBase;
using BikeDiller.EntityModels;
using BikeDiller.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BikeDiller.Repositories
{
    public class MakeRepository : IMakeRepository
    {
        BikeDillerDbContext _db;

        public MakeRepository(BikeDillerDbContext db)
        {
            _db = db;
        }


        private async Task<bool> Save()
        {
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddNew(Make make)
        {
             _db.Makes.Add(make);

            return await Save();

        }

        public async Task<IEnumerable<Make>> GetAll()
        {
            return await _db.Makes.ToListAsync();
        }

        public async Task<bool> DeleteEntity(Make make)
        {
            _db.Makes.Remove(make);
            return await Save();
        }

        public async Task<Make> GetById(int id)
        {
            return await _db.Makes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateEntity(Make make)
        {
            _db.Makes.Update(make);
            return await Save();
        }
    }
}
