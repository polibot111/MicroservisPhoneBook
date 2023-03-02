using PhoneBookService.Domain.Abstract;
using System.Linq.Expressions;

namespace PhoneBookService.Interface.Repositories.GenericRepositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<IQueryable<T>> GetAllAsync(CancellationToken cancellationToken, bool tracking = true);
        Task<IQueryable<T>> GetWhereAsync(CancellationToken cancellationToken, Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetSingleAsync(CancellationToken cancellationToken, Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetByIdAsync(CancellationToken cancellationToken, Guid id, bool tracking = true);

    }
}
