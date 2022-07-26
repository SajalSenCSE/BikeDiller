using BikeDiller.EntityModels;
using BikeDiller.Repositories.Abstraction;
using BikeDiller.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BikeDiller.Services
{
    public class ModelService : BaseService<Model>,IModelService
    {
        IModelRepository _modelRepository;

        public ModelService(IModelRepository modelRepository):base(modelRepository)
        {
            _modelRepository = modelRepository;
        }

       
    }
}
