using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PhoneBookService.Domain.Abstract;
using PhoneBookService.Infrastructure;
using PhoneBookService.Interface.Repositories.GenericRepositories;
using System.Linq.Expressions;

namespace PhoneBookService.Repositories.GenericRepositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly PhoneBookServiceDbContext _context;

        public ReadRepository(PhoneBookServiceDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<IQueryable<T>> GetAllAsync(CancellationToken cancellationToken, bool tracking = true)
        {

            return await Task.Run(() =>
            {
                var query = Table.AsQueryable().Where(x => x.IsDeleted == false);
                if (!tracking)
                    query = query.AsNoTracking();
                return query;
            });


        }
        public async Task<IQueryable<T>> GetWhereAsync(CancellationToken cancellationToken, Expression<Func<T, bool>> method, bool tracking = true)
        {
            return await Task.Run(() =>
            {
                var query = Table.Where(method);
                if (!tracking)
                    query = query.AsNoTracking();
                return query;
            });

        }

        public async Task<T> GetSingleAsync(CancellationToken cancellationToken, Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(method);
        }

        public async Task<T> GetByIdAsync(CancellationToken cancellationToken, Guid id, bool tracking = true) /*=> await Table.FirstOrDefaultAsync(p => p.Id == Guid.Parse(id));*/
        //=> await Table.FindAsync(Guid.Parse(id));
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.Id == id);
        }
    }
}
