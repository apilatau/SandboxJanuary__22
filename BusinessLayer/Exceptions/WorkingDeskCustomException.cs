using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Exceptions
{
    public class WorkingDeskCustomException : Exception
    {
        public WorkingDeskCustomException() { }
        public WorkingDeskCustomException(string message) : base(message) { }
    }
}
