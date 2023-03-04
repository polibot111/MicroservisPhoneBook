namespace ReportService.Services
{
    public class CreateReportService
    {
        readonly ContentService _contentService;
        readonly ReportOrderService _reportOrderService;
        public CreateReportService(ContentService contentService, ReportOrderService reportOrderService)
        {
            _contentService = contentService;
            _reportOrderService = reportOrderService;
        }
        //TODO : Buradan devam edilecek.

    }
}
