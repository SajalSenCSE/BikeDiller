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
    public class BikeRepository : BaseRepository<Bike> ,IBikeRepository
    {
        BikeDillerDbContext _db;

        public BikeRepository(BikeDillerDbContext db):base(db)
        {
            _db = db;
        }

        
        
        public override async Task<IEnumerable<Bike>> GetAll()
        {
            return await _db.Bikes
                            .Include(x=>x.Make)
                            .Include(y=>y.Model)
                            .Include(x=>x.Currency)
                            .ToListAsync();
        }

        public override async Task<Bike> GetById(int id)
        {
            return await _db.Bikes
                            .Include(x => x.Make)
                            .Include(y => y.Model)
                            .FirstOrDefaultAsync(z => z.Id == id);
        }

       

    }
}
