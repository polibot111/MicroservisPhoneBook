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

        [HttpGet("{Id}")]
        public async Task<ReportContentDTO> ReportContentGetAsync([FromRoute] ReportContentByIdQuery obj, CancellationToken cancellationToken)
        {
            return await _contentService.GetReportContentById(obj, cancellationToken);
        }

        [HttpPost]
        public async Task<string> ReportContentAsync([FromBody] ReportContentInsertCommand obj, CancellationToken cancellationToken)
        {
            return await _contentService.InsertReportContent(obj, cancellationToken);
        }

        [HttpDelete]
        public async Task<bool> ReportContentDeleteAsync([FromBody] ReportContentUpdateIsDeleted obj, CancellationToken cancellationToken)
        {
            return await _contentService.UpdateIsDeletedReportContent(obj, cancellationToken);
        }
    }
}
