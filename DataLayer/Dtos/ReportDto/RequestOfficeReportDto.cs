using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dtos.ReportDto
{
    public class RequestOfficeReportDto
    {
        public int OfficeId { get; set; }
        public ReportTimeline timeline { get; set; }
        public DetailsEnum detailsEnum { get; set; }
    }

}
