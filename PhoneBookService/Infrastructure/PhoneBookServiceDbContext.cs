using Microsoft.EntityFrameworkCore;
using PhoneBookService.Domain.Abstract;
using PhoneBookService.Domain.Entities;

namespace PhoneBookService.Infrastructure
{
    public class PhoneBookServiceDbContext : DbContext
    {
        public PhoneBookServiceDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Person> People { get; set; }
        public DbSet<CommunicationInfo> CommunicationInfos { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker
                .Entries<BaseEntity>();

            foreach (var data in datas)
            {
                switch (data.State)
                {
                    case EntityState.Added:
                        data.Entity.CreatedAt = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        data.Entity.UpdatedAt = DateTime.UtcNow;
                        break;
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
