using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Exceptions
{
    public class CityCustomException : Exception
    {
        public CityCustomException() { }
        public CityCustomException(string message) : base(message) { }
    }
}
