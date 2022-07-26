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
    public class ModelRepository : IModelRepository
    {
        BikeDillerDbContext _db;

        public ModelRepository(BikeDillerDbContext db)
        {
            _db = db;
        }

        private async Task<bool> Save()
        {
            return await _db.SaveChangesAsync()>0;
        }
        public async Task<bool> AddNew(Model model)
        {
            _db.Models.Add(model);
            return await Save();

        }

        public async Task<bool> DeleteEntity(Model model)
        {
            _db.Models.Remove(model);
            return await Save();
        }

        public async  Task<IEnumerable<Model>> GetAll()
        {
            return await _db.Models
                            .Include(c=>c.Make)
                            .ToListAsync();
        }

        public async Task<Model> GetById(int id)
        {
            return await _db.Models
                            .Include(c => c.Make)
                            .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateEntity(Model model)
        {
            _db.Models.Update(model);
            return await Save();
        }
    }
}
