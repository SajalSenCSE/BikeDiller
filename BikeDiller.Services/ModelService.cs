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

        public async Task<bool> AddNew(Model model)
        {
            return await _modelRepository.AddNew(model);
        }

        public async Task<bool> DeleteEntity(Model model)
        {
            return await _modelRepository.DeleteEntity(model);
        }

        public async Task<IEnumerable<Model>> GetAll()
        {
            return await _modelRepository.GetAll();
        }

        public async Task<Model> GetById(int id)
        {
            return await _modelRepository.GetById(id);
        }

        public async Task<bool> UpdateEntity(Model model)
        {
            return await _modelRepository.UpdateEntity(model);
        }
    }
}
