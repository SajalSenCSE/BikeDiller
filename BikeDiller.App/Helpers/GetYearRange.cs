using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeDiller.App.Helpers
{
    public class GetYearRange:RangeAttribute
    {
        public GetYearRange(int StratYear):base(StratYear,DateTime.Today.Year)
        {

        }
    }
}
