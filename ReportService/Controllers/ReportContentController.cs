using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReportService.Application.CQRS.ReportContent;
using ReportService.Application.CQRS.ReportOrder;
using ReportService.Application.DTO_s;
using ReportService.Interface;
using ReportService.Services;

namespace ReportService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportContentController : ControllerBase
    {
        readonly IContentService _contentService;
        public ReportContentController(IContentService contentService)
        {
            _contentService = contentService;
        }



        [HttpPost]
        public async Task<string> CreateReportContent([FromBody] ReportContentInsertCommand obj, CancellationToken cancellationToken)
        {
            return await _contentService.InsertReportContent(obj, cancellationToken);
        }

    }
}
