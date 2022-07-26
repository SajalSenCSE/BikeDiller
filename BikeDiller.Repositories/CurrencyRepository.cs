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
    public class CurrencyRepository : BaseRepository<Currency>,ICurrencyRepository
    {
        BikeDillerDbContext _db;

        public CurrencyRepository(BikeDillerDbContext db):base(db)
        {
            _db = db;
        }

        public override async Task<Currency> GetById(int id)
        {
            return await _db.Currencies.FirstOrDefaultAsync(x=>x.Id==id);
        }

       

        
    }
}
