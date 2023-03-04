using MongoDB.Bson;

namespace ReportService.Application.CQRS.ReportOrder
{
    public class ReportOrderByIdQuery
    {
        public string Id{ get; set; }
    }
}
