using ReportService.Domain.Abstract;

namespace ReportService.Domain.Entities
{
    public class Report:BaseEntity
    {
        public string Status { get; set; }
    }
}
