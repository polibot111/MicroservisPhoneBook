using MongoDB.Bson;
using ReportService.Domain.Abstract;

namespace ReportService.Domain.Entities
{
    public class ReportContent:BaseEntity
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string PersonCount { get; set; }
        public string CommunicationInfoCount { get; set; }
        public string ReportOrderId { get; set; }
    }
}
