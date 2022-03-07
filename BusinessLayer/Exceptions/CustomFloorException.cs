using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Exceptions
{
    public class CustomFloorException : Exception
    {
        public CustomFloorException() { }
        public CustomFloorException(string message) : base(message) { }
    }
}
