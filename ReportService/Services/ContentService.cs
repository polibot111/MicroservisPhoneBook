using MongoDB.Driver;
using ReportService.Application.CQRS.ReportContent;
using ReportService.Application.DTO_s;
using ReportService.Domain.Entities;
using ReportService.Infrastructure;
using ReportService.Interface;

namespace ReportService.Services
{
    public class ContentService: IContentService
    {

        private readonly IMongoCollection<ReportContent> _reportCollection;

        public ContentService(IReportServiceDbSettings reportServiceDbSettings)
        {
            var client = new MongoClient(reportServiceDbSettings.ConnectionString);

            var database = client.GetDatabase(reportServiceDbSettings.DatabaseName);

            _reportCollection = database.GetCollection<ReportContent>(reportServiceDbSettings.ReportContentCollectionName);

        }

        public async Task<ReportContentDTO> GetReportContentById(ReportContentByIdQuery obj, CancellationToken cancellationToken)
        {
            var result = (await _reportCollection.FindAsync(x => x.Id == obj.Id && x.IsDeleted == false)).FirstOrDefault();

            if (result is null)
            {
                return new();
            }

            return new()
            {
                Id = result.Id,
                Latitude = result.Latitude, 
                Longitude = result.Longitude,
                PersonCount = result.PersonCount,
                CommunicationInfoCount = result.CommunicationInfoCount
            };

        }

        public async Task<string> InsertReportContent(ReportContentInsertCommand obj, CancellationToken cancellationToken)
        {
            await _reportCollection.InsertOneAsync(new()
            {

                Id = obj.Id,
                CreatedAt = obj.CreatedAt,
                IsDeleted = obj.IsDeleted,
                Latitude = obj.Latitude,
                Longitude = obj.Longitude,
                PersonCount = obj.PersonCount,
                CommunicationInfoCount = obj.CommunicationInfoCount,
                ReportOrderId= obj.ReportOrderId

            }, cancellationToken);

            return obj.Id;

        }

        public async Task<bool> UpdateIsDeletedReportContent(ReportContentUpdateIsDeleted obj, CancellationToken cancellationToken)
        {
            var reportOrder = (await _reportCollection.FindAsync(x => x.Id == obj.Id && x.IsDeleted == false)).FirstOrDefault();
            var result = await _reportCollection.FindOneAndReplaceAsync(x => x.Id == obj.Id && x.IsDeleted == false, new ReportContent
            {
                Id = reportOrder.Id,
                CreatedAt = reportOrder.CreatedAt,
                UpdatedAt = DateTime.Now,
                IsDeleted = obj.IsDeleted,
                Latitude = reportOrder.Latitude,
                Longitude = reportOrder.Longitude,
                PersonCount = reportOrder.PersonCount,
                CommunicationInfoCount = reportOrder.CommunicationInfoCount,
                ReportOrderId = reportOrder.ReportOrderId
            });

            if (result is null)
            {
                return false;
            }
            return true;

        }

    }
}
