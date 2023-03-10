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


        public async Task<ReportContentDTO> GetReportContentByOrderId(ReportContentByOrderIdQuery obj, CancellationToken cancellationToken)
        {
            var result = (await _reportCollection.FindAsync(x => x.ReportOrderId == obj.ReportOrderId)).FirstOrDefault();

            if (result is null)
            {
                return new();
            }

            return new()
            {
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
                Latitude = obj.Latitude,
                Longitude = obj.Longitude,
                PersonCount = obj.PersonCount,
                CommunicationInfoCount = obj.CommunicationInfoCount,
                ReportOrderId= obj.ReportOrderId.ToString()

            }, cancellationToken);

            return obj.Id;

        }

    }
}
