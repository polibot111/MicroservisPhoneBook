using Microsoft.EntityFrameworkCore;
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

        public async Task<IQueryable<Person>> GetAllAsyncWithLocation(string Latitude, string Longitude, CancellationToken cancellationToken, bool tracking = true)
        {

            return await Task.Run(() =>
            {
                var query = Table.AsQueryable().Where(x => x.IsDeleted == false && x.CommunicationInfos.Any(z => z.Longitude == Longitude && z.Latitude == Latitude && z.IsDeleted == false)).Select(x => new Person
                {
                    Id = x.Id,
                    CommunicationInfos = (ICollection<CommunicationInfo>)x.CommunicationInfos.Where(z => z.Longitude == Longitude && z.Latitude == Latitude)
                });
                if (!tracking)
                    query = query.AsNoTracking();
                return query;
            });


        }
    }
}
