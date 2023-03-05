namespace ReportService.Application.CQRS.CreateReport
{
    public class CreateReportCommand
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
