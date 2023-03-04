using PhoneBookService.Interface.Repositories;

namespace PhoneBookService.Services
{
    public class ReportService
    {
        readonly IPersonReadRepository _personReadRepository;
        readonly ICommunicationInfoReadRepository _communicationInfoReadRepository;

        public ReportService(IPersonReadRepository personReadRepository, ICommunicationInfoReadRepository communicationInfoReadRepository)
        {
            _personReadRepository = personReadRepository;
            _communicationInfoReadRepository = communicationInfoReadRepository;
        }

        public async Task<>
    }
}
