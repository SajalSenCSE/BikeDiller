using BikeDiller.DataBase;
using BikeDiller.EntityModels;
using BikeDiller.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDiller.Repositories
{
    public class ModelRepository : BaseRepository<Model>,IModelRepository
    {
        BikeDillerDbContext _db;

        public ModelRepository(BikeDillerDbContext db):base(db)
        {
            _db = db;
        }


        public override async Task<IEnumerable<Model>> GetAll()
        {
            return await _db.Models
                            .Include(c=>c.Make)
                            .ToListAsync();
        }

        public override async Task<Model> GetById(int id)
        {
            return await _db.Models
                            .Include(c => c.Make)
                            .FirstOrDefaultAsync(x => x.Id == id);
        }

        
    }
}
