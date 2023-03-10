using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransitCommon.Model
{
    public class ReportModel: IReportModel
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string ReportOrderId { get; set; }
    }

    public interface IReportModel
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public string ReportOrderId { get; set; }
    }
}
