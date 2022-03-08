using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Exceptions
{
    public class CustomReserveException : Exception
    {
        public CustomReserveException() { }
        public CustomReserveException(string message) : base(message) { }
    }
}