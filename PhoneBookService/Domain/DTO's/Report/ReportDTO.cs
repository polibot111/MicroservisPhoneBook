namespace PhoneBookService.Domain.DTO_s.Report
{
    public class ReportDTO
    {
        public Guid ReportId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string PersonCount { get; set; }
        public string CommunicationInfoCount { get; set; }
    }
}
