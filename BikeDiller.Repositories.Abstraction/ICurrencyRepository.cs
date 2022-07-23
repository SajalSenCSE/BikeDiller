﻿using BikeDiller.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BikeDiller.Repositories.Abstraction
{
    public interface ICurrencyRepository
    {
        Task<IEnumerable<Currency>> GetCurrencies();
    }
}
