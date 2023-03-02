using PhoneBookService.Domain.Entities;
using PhoneBookService.Infrastructure;
using PhoneBookService.Interface.Repositories;
using PhoneBookService.Repositories.GenericRepositories;

namespace PhoneBookService.Repositories
{
    public class PersonWriteRepository : WriteRepository<Person>, IPersonWriteRepository
    {
        public PersonWriteRepository(PhoneBookServiceDbContext context) : base(context)
        {

        }
    }
}
