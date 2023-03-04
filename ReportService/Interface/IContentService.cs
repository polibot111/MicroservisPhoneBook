using ReportService.Application.CQRS.ReportContent;
using ReportService.Application.DTO_s;

namespace ReportService.Interface
{
    public interface IContentService
    {
        Task<ReportContentDTO> GetReportContentByOrderId(ReportContentByOrderIdQuery obj, CancellationToken cancellationToken);
        Task<string> InsertReportContent(ReportContentInsertCommand obj, CancellationToken cancellationToken);
    }
}
