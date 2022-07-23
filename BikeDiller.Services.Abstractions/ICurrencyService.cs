using BikeDiller.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BikeDiller.Services.Abstractions
{
    public interface ICurrencyService
    {
        Task<IEnumerable<Currency>> GetCurrencies();
    }
}
