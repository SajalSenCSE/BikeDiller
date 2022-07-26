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
    public class BikeRepository : IBikeRepository
    {
        BikeDillerDbContext _db;

        public BikeRepository(BikeDillerDbContext db)
        {
            _db = db;
        }

        private async Task<bool> Save()
        {
            return await _db.SaveChangesAsync()>0;
        }
        public Task<bool> AddNew(Bike bike)
        {
            _db.Bikes.Add(bike);
            return Save();
        }

        public async Task<bool> DeleteEntity(Bike bike)
        {
            _db.Bikes.Remove(bike);
            return await Save();
        }

        public async Task<IEnumerable<Bike>> GetAll()
        {
            return await _db.Bikes
                            .Include(x=>x.Make)
                            .Include(y=>y.Model)
                            .Include(x=>x.Currency)
                            .ToListAsync();
        }

        public async Task<Bike> GetById(int id)
        {
            return await _db.Bikes
                            .Include(x => x.Make)
                            .Include(y => y.Model)
                            .FirstOrDefaultAsync(z => z.Id == id);
        }

        public async Task<bool> UpdateEntity(Bike bike)
        {
            _db.Bikes.Update(bike);
            return await Save();
        }
    }
}
