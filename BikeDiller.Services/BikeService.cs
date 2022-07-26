using BikeDiller.EntityModels;
using BikeDiller.Repositories.Abstraction;
using BikeDiller.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BikeDiller.Services
{
    public class BikeService : BaseService<Bike>,IBikeService
    {
        IBikeRepository _bikeRepository;

        public BikeService(IBikeRepository bikeRepository):base(bikeRepository)
        {
            _bikeRepository = bikeRepository;
        }

       

    }
}
