using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Exceptions
{
    public class CountryCustomException : Exception
    {
        public CountryCustomException() { }
        public CountryCustomException(string message) : base(message) { }
    }
}
