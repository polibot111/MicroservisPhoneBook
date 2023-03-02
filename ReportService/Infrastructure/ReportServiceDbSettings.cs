﻿namespace ReportService.Infrastructure
{
    public class ReportServiceDbSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string ReportCollectionName { get; set; } = null!;
    }
}
