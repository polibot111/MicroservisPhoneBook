using MongoDB.Bson;
using MongoDB.Driver;
using ReportService.Application.CQRS.ReportContent;
using ReportService.Application.CQRS.ReportOrder;
using ReportService.Application.DTO_s;
using ReportService.Application.Enums;
using ReportService.Application.Extensions;
using ReportService.Domain.Entities;
using ReportService.Infrastructure;
using ReportService.Interface;

namespace ReportService.Services
{
    public class ReportOrderService : IReportOrderService
    {
        private readonly IMongoCollection<ReportOrder> _reportCollection;

        public ReportOrderService(IReportServiceDbSettings reportServiceDbSettings)
        {
            var client = new MongoClient(reportServiceDbSettings.ConnectionString);

            var database = client.GetDatabase(reportServiceDbSettings.DatabaseName);

            _reportCollection = database.GetCollection<ReportOrder>(reportServiceDbSettings.ReportOrderCollectionName);
        }

        public async Task<ReportOrderDTO> ReportOrderGetAsync(ReportOrderByIdQuery obj, CancellationToken cancellationToken)
        {
            var reportOrder = (await _reportCollection.FindAsync(x => x.Id == obj.Id && x.IsDeleted == false)).FirstOrDefault();



            if (reportOrder is null)
            {
                throw new Exception("Rapor Bulunamadı");
            }
            return new()
            {
                Status = reportOrder.Status,
                Message = $"Raporunuz {reportOrder.Status}."
            };



        }

        public async Task<string> ReportOrderInsertAsync(ReportOrderInsertCommand obj, CancellationToken cancellationToken)
        {
            await _reportCollection.InsertOneAsync(new()
            {

                Id = obj.Id,
                CreatedAt = obj.CreatedAt,
                Status = obj.Status,
                IsDeleted = obj.IsDeleted

            }, cancellationToken);

            return obj.Id;
        }

        public async Task<bool> ReportOrderUpdateStatusAsync(ReportOrderUpdateStatusCommand obj, CancellationToken cancellationToken)
        {
            var reportOrder = (await _reportCollection.FindAsync(x => x.Id == obj.Id && x.IsDeleted == false)).FirstOrDefault();
            var result = await _reportCollection.FindOneAndReplaceAsync(x => x.Id == obj.Id && x.IsDeleted == false, new ReportOrder
            {
                Id = obj.Id,
                CreatedAt = reportOrder.CreatedAt,
                UpdatedAt = DateTime.Now,
                Status = obj.Status.DisplayName(),
                Content = reportOrder.Content,
                ReportContentId = reportOrder.ReportContentId
            });

            if (result is null)
            {
                return false;
            }
            return true;

        }

        public async Task<bool> ReportOrderUpdateAsync(ReportOrderUpdateCommand obj, CancellationToken cancellationToken)
        {
            var reportOrder = (await _reportCollection.FindAsync(x => x.Id == obj.Id && x.IsDeleted == false)).FirstOrDefault();
            var result = await _reportCollection.FindOneAndReplaceAsync(x => x.Id == obj.Id && x.IsDeleted == false, new ReportOrder
            {
                Id = obj.Id,
                CreatedAt = reportOrder.CreatedAt,
                UpdatedAt = DateTime.Now,
                ReportContentId = obj.ReportContentId,
                Content = reportOrder.Content,
                Status = obj.Status.DisplayName()

            });

            if (result is null)
            {
                return false;
            }
            return true;

        }

        public async Task<bool> ReportOrderUpdateIsDeletedAsync(ReportOrderUpdateIsDeletedCommand obj, CancellationToken cancellationToken)
        {
            var reportOrder = (await _reportCollection.FindAsync(x => x.Id == obj.Id && x.IsDeleted == false)).FirstOrDefault();
            var result = await _reportCollection.FindOneAndReplaceAsync(x => x.Id == obj.Id && x.IsDeleted == false, new ReportOrder
            {
                Id = obj.Id,
                CreatedAt = reportOrder.CreatedAt,
                UpdatedAt = DateTime.Now,
                ReportContentId = reportOrder.ReportContentId,
                Content = reportOrder.Content,
                Status = reportOrder.Status,
                IsDeleted = obj.IsDeleted
            });

            if (result is null)
            {
                return false;
            }
            return true;

        }
    }
}
