using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Responses
{
    public class OfficeResponse<T>
    {
        public bool Success { get; set; } = true;
        public string ErrorMessage { get; set; }
        public Map map { get; set; }
        // map ids ...
    }
}