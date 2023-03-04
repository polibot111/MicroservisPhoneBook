using ReportService.Domain.Entities;

namespace ReportService.Application.DTO_s
{
    public class ReportOrderDTO
    {
        public string Message { get; set; }
        public ReportContent? Content { get; set; }
    }
}
