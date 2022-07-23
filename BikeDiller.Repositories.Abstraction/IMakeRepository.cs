using BikeDiller.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BikeDiller.Repositories.Abstraction
{
    public interface IMakeRepository
    {
        Task<IEnumerable<Make>> GetAllMakes();

        Task<bool> AddNewMake(Make make);
        Task<bool> DeleteMake(Make make);

        Task<Make> GetById(int id);

        Task<bool> UpdateMake(Make make);
        

    }
}
