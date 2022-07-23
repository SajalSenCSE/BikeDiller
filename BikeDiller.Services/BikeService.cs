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

        public async Task<bool> AddBike(Bike bike)
        {
            return await _bikeRepository.AddBike(bike);
        }

        public async Task<bool> DeleteBike(Bike bike)
        {
            return await _bikeRepository.DeleteBike(bike);
        }

        public async Task<IEnumerable<Bike>> GetAllBike()
        {
            return await _bikeRepository.GetAllBike();
        }

        public async Task<Bike> GetById(int id)
        {
            return await _bikeRepository.GetById(id);
        }

        public async Task<bool> UpdateBike(Bike bike)
        {
            return await _bikeRepository.UpdateBike(bike);
        }
    }
}
