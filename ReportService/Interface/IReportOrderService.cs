using MongoDB.Bson;
using ReportService.Application.CQRS.ReportOrder;
using ReportService.Application.DTO_s;

namespace ReportService.Interface
{
    public interface IReportOrderService
    {
        Task<ReportOrderDTO> ReportOrderGetAsync(ReportOrderByIdQuery obj, CancellationToken cancellationToken);
        Task<string> ReportOrderInsertAsync(ReportOrderInsertCommand obj, CancellationToken cancellationToken);
        Task<bool> ReportOrderUpdateStatusAsync(ReportOrderUpdateStatusCommand obj, CancellationToken cancellationToken);
        Task<bool> ReportOrderUpdateAsync(ReportOrderUpdateCommand obj, CancellationToken cancellationToken);
        Task<bool> ReportOrderUpdateIsDeletedAsync(ReportOrderUpdateIsDeletedCommand obj, CancellationToken cancellationToken);
    }
}
