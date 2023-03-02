using PhoneBookService.Domain.Abstract;

namespace PhoneBookService.Interface.Repositories.GenericRepositories
{
    public interface IRepository<T> where T:BaseEntity
    {
    }
}
