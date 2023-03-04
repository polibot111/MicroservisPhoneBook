using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReportService.Application.CQRS.ReportOrder;
using ReportService.Application.DTO_s;
using ReportService.Interface;

namespace ReportService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportOrderController : ControllerBase
    {
        readonly IReportOrderService _reportOrderService;

        public ReportOrderController(IReportOrderService reportOrderService)
        {
            _reportOrderService = reportOrderService;
        }

        [HttpGet("{Id}")]
        public async Task<ReportOrderDTO> ReportOrderGetAsync([FromRoute] ReportOrderByIdQuery obj, CancellationToken cancellationToken)
        {
            return await _reportOrderService.ReportOrderGetAsync(obj, cancellationToken);
        }

        [HttpPost]
        public async Task<string> ReportOrderInsertAsync([FromBody]ReportOrderInsertCommand obj, CancellationToken cancellationToken)
        {
            return await _reportOrderService.ReportOrderInsertAsync(obj, cancellationToken);
        }

        [HttpPut]
        public async Task<bool> ReportOrderUpdateStatusAsync([FromBody] ReportOrderUpdateStatusCommand obj, CancellationToken cancellationToken)
        {
            return await _reportOrderService.ReportOrderUpdateStatusAsync(obj, cancellationToken);
        }

        [HttpDelete]
        public async Task<bool> ReportOrderUpdateIsDeletedAsync([FromBody] ReportOrderUpdateIsDeletedCommand obj, CancellationToken cancellationToken)
        {
            return await _reportOrderService.ReportOrderUpdateIsDeletedAsync(obj, cancellationToken);
        }
    }
}
