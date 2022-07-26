using BikeDiller.EntityModels;
using BikeDiller.Repositories.Abstraction;
using BikeDiller.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BikeDiller.Services
{
    public class MakeService : IMakeService
    {
        IMakeRepository _makeRepository;

        public MakeService(IMakeRepository makeRepository)
        {
            _makeRepository = makeRepository;
        }

        public async Task<bool> AddNew(Make make)
        {
            return await _makeRepository.AddNew(make);
        }

        public async Task<bool> DeleteEntity(Make make)
        {
            return await _makeRepository.DeleteEntity(make);
        }

        public async Task<IEnumerable<Make>> GetAll()
        {
            return await _makeRepository.GetAll();
        }

        public async Task<Make> GetById(int id)
        {
            return await _makeRepository.GetById(id);
        }

        public async Task<bool> UpdateEntity(Make make)
        {
            return await _makeRepository.UpdateEntity(make);
        }
    }
}
