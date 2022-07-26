using BikeDiller.EntityModels;
using BikeDiller.Repositories.Abstraction;
using BikeDiller.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BikeDiller.Services
{
    public class MakeService : BaseService<Make>,IMakeService
    {
        IMakeRepository _makeRepository;

        public MakeService(IMakeRepository makeRepository):base(makeRepository)
        {
            _makeRepository = makeRepository;
        }


    }
}
