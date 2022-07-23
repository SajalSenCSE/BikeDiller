﻿using BikeDiller.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BikeDiller.Repositories.Abstraction
{
    public interface IBikeRepository
    {
        Task<IEnumerable<Bike>> GetAllBike();
        Task<Bike> GetById(int id);
        Task<bool> AddBike(Bike bike);
        Task<bool> UpdateBike(Bike bike);
        Task<bool> DeleteBike(Bike bike);

    }
}