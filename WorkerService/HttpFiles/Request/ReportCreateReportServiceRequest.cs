namespace WorkerService.HttpFiles.Request
{
    public class ReportCreateReportServiceRequest
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string PersonCount { get; set; }
        public string CommunicationInfoCount { get; set; }
        public Guid ReportOrderId { get; set; }
    }
}
