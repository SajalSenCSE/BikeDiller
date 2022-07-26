using BikeDiller.EntityModels;
using BikeDiller.Repositories.Abstraction;
using BikeDiller.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BikeDiller.Services
{
    public class BikeService : IBikeService
    {
        IBikeRepository _bikeRepository;

        public BikeService(IBikeRepository bikeRepository)
        {
            _bikeRepository = bikeRepository;
        }

        public async Task<bool> AddNew(Bike bike)
        {
            return await _bikeRepository.AddNew(bike);
        }

        public async Task<bool> DeleteEntity(Bike bike)
        {
            return await _bikeRepository.DeleteEntity(bike);
        }

        public async Task<IEnumerable<Bike>> GetAll()
        {
            return await _bikeRepository.GetAll();
        }

        public async Task<Bike> GetById(int id)
        {
            return await _bikeRepository.GetById(id);
        }

        public async Task<bool> UpdateEntity(Bike bike)
        {
            return await _bikeRepository.UpdateEntity(bike);
        }
    }
}
