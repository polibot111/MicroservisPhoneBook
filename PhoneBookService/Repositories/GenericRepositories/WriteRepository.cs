using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using PhoneBookService.Domain.Abstract;
using PhoneBookService.Interface.Repositories.GenericRepositories;
using PhoneBookService.Infrastructure;

namespace PhoneBookService.Repositories.GenericRepositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly PhoneBookServiceDbContext _context;

        public WriteRepository(PhoneBookServiceDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model, CancellationToken cancellationToken)
        {
            EntityEntry<T> entity = await Table.AddAsync(model);
            return entity.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> datas, CancellationToken cancellationToken)
        {
            await Table.AddRangeAsync(datas);
            return true;
        }

        public async Task<bool> UpdateAsync(T model, CancellationToken cancellationToken)
        {

            return await Task.Run(() =>
            {
                EntityEntry entity = Table.Update(model);
                return entity.State == EntityState.Modified;
            });

        }

        public async Task<bool> UpdateStatusAsync(T model, CancellationToken cancellationToken)
        {

            return await Task.Run(() =>
            {
                model.IsDeleted = true;
                EntityEntry entity = Table.Update(model);
                return entity.State == EntityState.Modified;
            });

        }

        public async Task<int> SaveAsync(CancellationToken cancellationToken) => await _context.SaveChangesAsync();

    }
}
