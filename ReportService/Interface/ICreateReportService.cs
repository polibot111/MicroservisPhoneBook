using ReportService.Application.CQRS.ReportContent;
using ReportService.Application.CQRS.ReportOrder;
using ReportService.Application.DTO_s;

namespace ReportService.Interface
{
    public interface ICreateReportService
    {
        Task<CreateReportDTO> GetCreatedReport(string Orderid, CancellationToken cancellationToken);

        Task<string> CreateReportContent(ReportContentInsertCommand obj, CancellationToken cancellationToken);
        Task<string> CreateReportOrder(ReportOrderInsertCommand obj, CancellationToken cancellationToken);
    }
}
