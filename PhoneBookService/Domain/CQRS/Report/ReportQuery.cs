namespace PhoneBookService.Domain.CQRS.Report
{
    public class ReportQuery
    {
        public Guid ReportId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
