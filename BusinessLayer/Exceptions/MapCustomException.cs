using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Exceptions
{
    public class MapCustomException : Exception
    {
        public MapCustomException() { }
        public MapCustomException(string message) : base(message) { }
    }
}
