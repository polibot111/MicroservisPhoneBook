using ReportService.Application.CQRS.ReportContent;
using ReportService.Application.CQRS.ReportOrder;
using ReportService.Application.DTO_s;
using ReportService.Application.Enums;
using ReportService.Application.Extensions;
using ReportService.Domain.Entities;
using ReportService.Interface;
using System.Threading;

namespace ReportService.Services
{
    public class CreateReportService : ICreateReportService
    {
        private readonly IReportOrderService _reportOrderService;
        readonly IContentService _contentService;

        public CreateReportService(IReportOrderService reportOrderService, IContentService contentService)
        {
            _reportOrderService = reportOrderService;
            _contentService = contentService;
        }

        public async Task<CreateReportDTO> GetCreatedReport(string Orderid, CancellationToken cancellationToken)
        {
            var resultOrder = await _reportOrderService.ReportOrderGetAsync(new Application.CQRS.ReportOrder.ReportOrderByIdQuery() { Id = Orderid },cancellationToken);

            if (resultOrder.Status == ReportStatuEnum.Inceleniyor.DisplayName())
            {
                return new()
                {
                    Message = $"Raporunuz {resultOrder.Status}."
                };
            }
            else if (resultOrder.Status == ReportStatuEnum.Tamamlandı.DisplayName())
            {
                var contentOrder = await _contentService.GetReportContentByOrderId(new ReportContentByOrderIdQuery { ReportOrderId = Orderid }, cancellationToken);
                return new()
                {
                    Message = $"Raporunuz {resultOrder.Status}.",
                    Content = contentOrder
                };

            }
            else
            {
                return new()
                {
                    Message = $"Raporunuz {resultOrder.Status}."
                };
            }
        }

        public async Task<string> CreateReportContent(ReportContentInsertCommand obj , CancellationToken cancellationToken)
        {

            var result = await _reportOrderService.ReportOrderGetAsync(new() { Id = obj.ReportOrderId.ToString() }, cancellationToken);

            if (result is null)
            {
                return "Rapor bulunamadı.";
            }

            return await _contentService.InsertReportContent(obj, cancellationToken);

        }

        public async Task<string> CreateReportOrder(ReportOrderInsertCommand obj, CancellationToken cancellationToken)
        {
            var result = await _reportOrderService.ReportOrderInsertAsync(obj, cancellationToken);
            return result;
        }
    }
}
