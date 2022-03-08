using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dtos.ReportDto
{
    public class GetReportDto
    {
        public float PercentageOfBookedWorkplaces { get; set; }
        public int NumberOfBookedWorkplaces { get; set; }
        public int NumberOfFreeWorkplaces { get; set; }
    }
}