using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epsic_Cave_A_Vin_Ethan.Exceptions
{
    public class DataNotFoundException : Exception
    {
        public DataNotFoundException(string message) : base(message)
        {

        }
    }
}
