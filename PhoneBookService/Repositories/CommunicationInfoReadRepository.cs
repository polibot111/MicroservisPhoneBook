using PhoneBookService.Domain.Entities;
using PhoneBookService.Infrastructure;
using PhoneBookService.Interface.Repositories;
using PhoneBookService.Repositories.GenericRepositories;

namespace PhoneBookService.Repositories
{
    public class CommunicationInfoReadRepository : ReadRepository<CommunicationInfo>, ICommunicationInfoReadRepository
    {
        public CommunicationInfoReadRepository(PhoneBookServiceDbContext context) : base(context)
        {

        }
    }
}
