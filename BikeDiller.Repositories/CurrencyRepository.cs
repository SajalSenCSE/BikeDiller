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
    public class CurrencyRepository : ICurrencyRepository
    {
        BikeDillerDbContext _db;

        public CurrencyRepository(BikeDillerDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Currency>> GetCurrencies()
        {
            return await _db.Currencies.ToListAsync();
        }
    }
}
