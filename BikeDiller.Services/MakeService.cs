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

        public async Task<bool> AddNewMake(Make make)
        {
            return await _makeRepository.AddNewMake(make);
        }

        public async Task<bool> DeleteMake(Make make)
        {
            return await _makeRepository.DeleteMake(make);
        }

        public async Task<IEnumerable<Make>> GetAllMakes()
        {
            return await _makeRepository.GetAllMakes();
        }

        public async Task<Make> GetById(int id)
        {
            return await _makeRepository.GetById(id);
        }

        public async Task<bool> UpdateMake(Make make)
        {
            return await _makeRepository.UpdateMake(make);
        }
    }
}
