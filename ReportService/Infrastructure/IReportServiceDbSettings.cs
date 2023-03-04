namespace ReportService.Infrastructure
{
    public interface IReportServiceDbSettings
    {
        public string ConnectionString { get; set; } 

        public string DatabaseName { get; set; } 

        public string ReportOrderCollectionName { get; set; } 
        public string ReportContentCollectionName { get; set; } 
    }
}
