using BikeDiller.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BikeDiller.Repositories.Abstraction
{
    public interface IModelRepository
    {
        Task<IEnumerable<Model>> GetAllModels();
        Task<Model> GetById(int id);
        Task<bool> AddModel(Model model);
        Task<bool> Delete(Model model);
        Task<bool> Update(Model model);
    }
}
