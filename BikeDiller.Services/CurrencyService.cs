using BikeDiller.EntityModels;
using BikeDiller.Repositories.Abstraction;
using BikeDiller.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BikeDiller.Services
{
    public class CurrencyService:BaseService<Currency>,ICurrencyService
    {
        ICurrencyRepository _currencyRepository;

        public CurrencyService(ICurrencyRepository currencyRepository):base(currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

       
    }
}
