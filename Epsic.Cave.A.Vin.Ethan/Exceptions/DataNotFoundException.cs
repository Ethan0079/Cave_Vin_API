using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epsic.Cave.A.Vin.Ethan.Exceptions
{
    public class DataNotFoundException : Exception
    {
        public DataNotFoundException(string message) : base(message)
        {

        }
    }
}
