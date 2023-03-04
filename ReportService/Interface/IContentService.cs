using ReportService.Application.CQRS.ReportContent;
using ReportService.Application.DTO_s;

namespace ReportService.Interface
{
    public interface IContentService
    {
        Task<ReportContentDTO> GetReportContentById(ReportContentByIdQuery obj, CancellationToken cancellationToken);
        Task<string> InsertReportContent(ReportContentInsertCommand obj, CancellationToken cancellationToken);
        Task<bool> UpdateIsDeletedReportContent(ReportContentUpdateIsDeleted obj, CancellationToken cancellationToken);
    }
}
