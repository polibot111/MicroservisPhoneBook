using MassTransitCommon.Enums;
using MassTransitCommon.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReportService.Application.CQRS.CreateReport;
using ReportService.Application.CQRS.ReportContent;
using ReportService.Application.CQRS.ReportOrder;
using ReportService.Application.DTO_s;
using ReportService.Domain.Entities;
using ReportService.Interface;
using ReportService.MassTransit;
using ReportService.Services;

namespace ReportService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CreateReportController : ControllerBase
    {
        readonly ICreateReportService _createReportService;
        public CreateReportController(ICreateReportService createReportService)
        {
            _createReportService = createReportService;
        }

        [HttpGet("{Id}")]
        public async Task<CreateReportDTO> GetCreatedReport([FromRoute] string Id, CancellationToken cancellationToken)
        {
            return await _createReportService.GetCreatedReport(Id, cancellationToken);
        }

        [HttpPost]
        public async Task<string> CreateReportContent([FromBody] ReportContentInsertCommand obj, CancellationToken cancellationToken)
        {
            return await _createReportService.CreateReportContent(obj, cancellationToken);
        }

        [HttpPost]
        public async Task<string> CreateReportOrder([FromBody] CreateReportCommand obj , CancellationToken cancellationToken)
        {
            string reportOrderId = await _createReportService.CreateReportOrder(new(), cancellationToken);

            List<QueueEnum> queueEnums = new List<QueueEnum>();
            queueEnums.Add(QueueEnum.ReportOrder);
            await MassTransitPublisher.Publisher(queueEnums, new ReportModel { ReportOrderId = reportOrderId, Latitude = obj.Latitude, Longitude = obj.Longitude });

            return reportOrderId;
        }

    }
}
