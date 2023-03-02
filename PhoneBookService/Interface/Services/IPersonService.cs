using PhoneBookService.Domain.CQRS.Person;
using PhoneBookService.Domain.DTO_s.Person;

namespace PhoneBookService.Interface.Services
{
    public interface IPersonService
    {
        Task<List<PersonDTO>> GetPersonList(PersonQuery obj, CancellationToken cancellationToken);
        Task<PersonDetailDTO> GetPersonDetailById(PersonReadByIdQuery obj, CancellationToken cancellationToken);
        Task<bool> InsertPerson(PersonInsertCommand obj, CancellationToken cancellationToken);
        Task<bool> UpdatePerson(PersonUpdateCommand obj, CancellationToken cancellationToken);
        Task<bool> UpdateIsDeletedPerson(PersonUpdateIsDeletedCommand obj, CancellationToken cancellationToken);


    }
}
