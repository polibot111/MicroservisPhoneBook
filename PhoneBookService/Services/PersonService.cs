using PhoneBookService.Domain.CQRS.Person;
using PhoneBookService.Domain.DTO_s.Person;
using PhoneBookService.Interface.Repositories;
using PhoneBookService.Interface.Services;
using PhoneBookService.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PhoneBookService.Services
{
    public class PersonService:IPersonService
    {
        readonly IPersonReadRepository _personReadRepository;
        readonly ICommunicationInfoService _communicationInfoService;
        readonly IPersonWriteRepository _personWriteRepository;
        public PersonService(IPersonReadRepository personReadRepository, IPersonWriteRepository personWriteRepository, ICommunicationInfoService communicationInfoService)
        {
            _personReadRepository = personReadRepository;
            _personWriteRepository = personWriteRepository;
            _communicationInfoService = communicationInfoService;
        }

        public async Task<List<PersonDTO>> GetPersonList(PersonQuery obj, CancellationToken cancellationToken)
        {
            try
            {
                var persons = (await _personReadRepository.GetAllAsync(cancellationToken)).Select(x => new PersonDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Surname = x.Surname,
                    Company = x.Company
                }).ToList();

                return persons;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }

        }

        public async Task<PersonDetailDTO> GetPersonDetailById(PersonReadByIdQuery obj, CancellationToken cancellationToken)
        {
            try
            {
                var person = await _personReadRepository.GetByIdAsync(cancellationToken, obj.Id);
            
                return new PersonDetailDTO
                {
                    Id = person.Id,
                    Name = person.Name,
                    Surname = person.Surname,
                    Company = person.Company,
                    Communications = await _communicationInfoService.GetCommunicationInfoList(new() { PersonId = person.Id }, cancellationToken),
                };
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
  
        }

        public async Task<bool> InsertPerson(PersonInsertCommand obj, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _personWriteRepository.AddAsync(new()
                {
                    Id = Guid.NewGuid(),
                    Name = obj.Name,
                    Surname = obj.Surname,
                    Company = obj.Company
                }, cancellationToken);

                await _personWriteRepository.SaveAsync(cancellationToken);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }



        }

        public async Task<bool> UpdatePerson(PersonUpdateCommand obj, CancellationToken cancellationToken)
        {
            try
            {
                var person = await _personReadRepository.GetByIdAsync(cancellationToken, obj.Id);

                person.Surname = obj.Surname;
                person.Company = obj.Company;
                person.Name = obj.Name;

                await _personWriteRepository.SaveAsync(cancellationToken);

                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
         
        }

        public async Task<bool> UpdateIsDeletedPerson(PersonUpdateIsDeletedCommand obj, CancellationToken cancellationToken)
        {
            try
            {
                var person = await _personReadRepository.GetByIdAsync(cancellationToken, obj.Id);

                person.IsDeleted = true;

                await _personWriteRepository.SaveAsync(cancellationToken);

                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }

        }
    }
}
