using BikeDiller.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BikeDiller.Services.Abstractions
{
    public interface IMakeService
    {
        Task<IEnumerable<Make>> GetAllMakes();
        Task<Make> GetById(int id);

        Task<bool> AddNewMake(Make make);

        Task<bool> DeleteMake(Make make);

        Task<bool> UpdateMake(Make make);

    }
}
