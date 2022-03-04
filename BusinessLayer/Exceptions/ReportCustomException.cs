using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Exceptions
{
    public class ReportCustomException : Exception
    {
        public ReportCustomException() { }
        public ReportCustomException(string message) : base(message) { }
    }
}
