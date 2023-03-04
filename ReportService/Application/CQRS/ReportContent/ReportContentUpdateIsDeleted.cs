namespace ReportService.Application.CQRS.ReportContent
{
    public class ReportContentUpdateIsDeleted
    {
        public string Id { get; set; }
        public bool IsDeleted { get; set; } = true;
    }
}
