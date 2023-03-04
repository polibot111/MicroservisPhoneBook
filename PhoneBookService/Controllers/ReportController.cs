using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBookService.Domain.CQRS.Report;
using PhoneBookService.Domain.DTO_s.Report;
using PhoneBookService.Interface.Services;

namespace PhoneBookService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        public async Task<ReportDTO> GetReportByLocation(ReportQuery obj, CancellationToken cancellationToken )
        {
            return await _reportService.CreateReport(obj,cancellationToken);
        }
    }
}
