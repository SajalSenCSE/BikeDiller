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
    public class MakeRepository : BaseRepository<Make> ,IMakeRepository
    {
        BikeDillerDbContext _db;

        public MakeRepository(BikeDillerDbContext db):base(db)
        {
            _db = db;
        }

       
        public override async Task<Make> GetById(int id)
        {
            return await _db.Makes.FirstOrDefaultAsync(x => x.Id == id);
        }

     
    }
}
