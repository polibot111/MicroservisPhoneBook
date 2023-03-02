using PhoneBookService.Domain.Abstract;

namespace PhoneBookService.Interface.Repositories.GenericRepositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model, CancellationToken cancellationToken);
        Task<bool> AddRangeAsync(List<T> datas, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(T model, CancellationToken cancellationToken);
        Task<bool> UpdateStatusAsync(T model, CancellationToken cancellationToken);

        Task<int> SaveAsync(CancellationToken cancellationToken);

    }
}
