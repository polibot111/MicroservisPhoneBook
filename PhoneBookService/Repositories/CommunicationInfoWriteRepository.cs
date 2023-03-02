using PhoneBookService.Domain.Entities;
using PhoneBookService.Infrastructure;
using PhoneBookService.Interface.Repositories;
using PhoneBookService.Repositories.GenericRepositories;

namespace PhoneBookService.Repositories
{
    public class CommunicationInfoWriteRepository : WriteRepository<CommunicationInfo>, ICommunicationInfoWriteRepository
    {
        public CommunicationInfoWriteRepository(PhoneBookServiceDbContext context) : base(context)
        {

        }
    }
}
