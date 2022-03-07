using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Exceptions
{
    public class OfficeCustomException : Exception
    {
        public OfficeCustomException() { }
        public OfficeCustomException(string message) : base(message) { }
    }
}