namespace ReportService.Infrastructure
{
    public class ReportServiceDbSettings: IReportServiceDbSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string ReportOrderCollectionName { get; set; }
        public string ReportContentCollectionName { get; set; }
    }
}
