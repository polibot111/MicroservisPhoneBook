

namespace ReportService.Application.CQRS.ReportContent
{
    public class ReportContentInsertCommand
    {


        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string PersonCount { get; set; }
        public string CommunicationInfoCount { get; set; }
        public Guid ReportOrderId { get; set; }
    }

}
