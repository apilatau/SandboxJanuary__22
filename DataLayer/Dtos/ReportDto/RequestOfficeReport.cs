using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dtos.ReportDto
{
    public class RequestOfficeReport
    {
        public int OfficeId { get; set; }
        public ReportTimeline Timeline { get; set; }
        public DetailsEnum DetailsEnum { get; set; }
    }
}
