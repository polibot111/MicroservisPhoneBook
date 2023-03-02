using PhoneBookService.Domain.Entities;
using PhoneBookService.Infrastructure;
using PhoneBookService.Interface.Repositories;
using PhoneBookService.Repositories.GenericRepositories;

namespace PhoneBookService.Repositories
{
    public class PersonReadRepository : ReadRepository<Person>, IPersonReadRepository
    {
        public PersonReadRepository(PhoneBookServiceDbContext context) : base(context)
        {

        }
    }
}
