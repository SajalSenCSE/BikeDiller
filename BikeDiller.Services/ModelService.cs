using BikeDiller.EntityModels;
using BikeDiller.Repositories.Abstraction;
using BikeDiller.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BikeDiller.Services
{
    public class ModelService : IModelService
    {
        IModelRepository _modelRepository;

        public ModelService(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }

        public async Task<bool> AddModel(Model model)
        {
            return await _modelRepository.AddModel(model);
        }

        public async Task<bool> Delete(Model model)
        {
            return await _modelRepository.Delete(model);
        }

        public async Task<IEnumerable<Model>> GetAllModels()
        {
            return await _modelRepository.GetAllModels();
        }

        public async Task<Model> GetById(int id)
        {
            return await _modelRepository.GetById(id);
        }

        public async Task<bool> Update(Model model)
        {
            return await _modelRepository.Update(model);
        }
    }
}
