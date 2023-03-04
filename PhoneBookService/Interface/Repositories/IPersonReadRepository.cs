using PhoneBookService.Domain.Entities;
using PhoneBookService.Interface.Repositories.GenericRepositories;

namespace PhoneBookService.Interface.Repositories
{
    public interface IPersonReadRepository: IReadRepository<Person>
    {
        Task<IQueryable<Person>> GetAllAsyncWithLocation(string Latitude, string Longitude, CancellationToken cancellationToken, bool tracking = true);
    }
}
