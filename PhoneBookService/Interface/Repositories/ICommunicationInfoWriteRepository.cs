using PhoneBookService.Domain.Entities;
using PhoneBookService.Interface.Repositories.GenericRepositories;

namespace PhoneBookService.Interface.Repositories
{
    public interface ICommunicationInfoWriteRepository: IWriteRepository<CommunicationInfo>
    {
    }
}
