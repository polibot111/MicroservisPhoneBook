using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBookService.Domain.CQRS.Person;
using PhoneBookService.Domain.DTO_s.Person;
using PhoneBookService.Interface.Repositories;
using PhoneBookService.Interface.Services;

namespace PhoneBookService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<List<PersonDTO>> Get([FromQuery]PersonQuery obj, CancellationToken cancellationToken)
        {
            return await _personService.GetPersonList(obj, cancellationToken);
        }

        [HttpGet("{Id}")]
        public async Task<PersonDetailDTO> GetById([FromRoute]PersonReadByIdQuery obj, CancellationToken cancellationToken)
        {
            return await _personService.GetPersonDetailById(obj, cancellationToken);
        }

        [HttpPost]
        public async Task<bool> Insert([FromBody]PersonInsertCommand obj, CancellationToken cancellationToken)
        {
            return await _personService.InsertPerson(obj, cancellationToken);
        }

        [HttpPut]
        public async Task<bool> Update([FromBody]PersonUpdateCommand obj, CancellationToken cancellationToken)
        {
            return await _personService.UpdatePerson(obj, cancellationToken);
        }

        [HttpDelete]
        public async Task<bool> UpdateIsDeleted([FromBody]PersonUpdateIsDeletedCommand obj, CancellationToken cancellationToken)
        {
            return await _personService.UpdateIsDeletedPerson(obj, cancellationToken);
        }
    }
}
