using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeDiller.App.InitialData
{
    public interface IDbInitialzer
    {
        public  Task Initialize();
    }
}
