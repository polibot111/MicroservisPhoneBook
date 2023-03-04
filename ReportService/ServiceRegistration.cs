using ReportService.Infrastructure;
using ReportService.Interface;
using ReportService.Services;

namespace ReportService
{
    public static class ServiceRegistration
    {

        public static void AddReportServices(this IServiceCollection services)
        {
            services.AddScoped<IReportOrderService, ReportOrderService>();
        }
    }
}
