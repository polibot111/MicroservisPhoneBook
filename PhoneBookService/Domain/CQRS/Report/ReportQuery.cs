namespace PhoneBookService.Domain.CQRS.Report
{
    public class ReportQuery
    {
        public Guid ReportOrderId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
