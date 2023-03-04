using Microsoft.EntityFrameworkCore;
using PhoneBookService.Domain.CQRS.Report;
using PhoneBookService.Domain.DTO_s.Report;
using PhoneBookService.Domain.Entities;
using PhoneBookService.Interface.Repositories;
using PhoneBookService.Interface.Services;

namespace PhoneBookService.Services
{
    public class ReportService : IReportService
    {
        readonly IPersonReadRepository _personReadRepository;
        readonly ICommunicationInfoReadRepository _communicationInfoReadRepository;

        public ReportService(IPersonReadRepository personReadRepository, ICommunicationInfoReadRepository communicationInfoReadRepository)
        {
            _personReadRepository = personReadRepository;
            _communicationInfoReadRepository = communicationInfoReadRepository;
        }

        public async Task<ReportDTO> CreateReport(ReportQuery obj, CancellationToken cancellationToken)
        {
            try
            {

                var people = (await _personReadRepository.GetAllAsyncWithLocation(obj.Latitude, obj.Longitude, cancellationToken)).Select(x => new Person
                {
                    Id = x.Id,
                    CommunicationInfos= x.CommunicationInfos,
                });

                int communicationInfoCount = 0;

                foreach (var item in people)
                {
                    communicationInfoCount += item.CommunicationInfos.Count;
                }

                return new ReportDTO
                {
                    ReportOrderId = obj.ReportOrderId,
                    Latitude = obj.Latitude,
                    Longitude = obj.Longitude,
                    PersonCount = people.Count().ToString(),
                    CommunicationInfoCount = communicationInfoCount.ToString(),
                };

            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        } 
    }
}
