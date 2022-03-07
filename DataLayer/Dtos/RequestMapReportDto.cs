using DataLayer.Dtos.ReportDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dtos
{
    public class RequestMapReportDto
    {
        public int MapId { get; set; }
        public ReportTimeline Timeline { get; set; }
        public DetailsEnum DetailsEnum { get; set; }
    }
}
