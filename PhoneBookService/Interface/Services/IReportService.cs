using PhoneBookService.Domain.CQRS.Report;
using PhoneBookService.Domain.DTO_s.Report;

namespace PhoneBookService.Interface.Services
{
    public interface IReportService
    {
        Task<ReportDTO> CreateReport(ReportQuery obj, CancellationToken cancellationToken);
    }
}
