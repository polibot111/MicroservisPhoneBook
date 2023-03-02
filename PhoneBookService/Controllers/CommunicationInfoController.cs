using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBookService.Domain.CQRS.CommunicationInfo;
using PhoneBookService.Domain.CQRS.Person;
using PhoneBookService.Domain.DTO_s.CommunicationInfo;
using PhoneBookService.Domain.DTO_s.Person;
using PhoneBookService.Interface.Services;
using PhoneBookService.Services;

namespace PhoneBookService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunicationInfoController : ControllerBase
    {
        readonly ICommunicationInfoService _communicationInfoService;

        public CommunicationInfoController(ICommunicationInfoService communicationInfoService)
        {
            _communicationInfoService = communicationInfoService;
        }

        [HttpGet]
        public async Task<List<CommunicationInfoDTO>> Get([FromQuery] CommunicationInfoQuery obj, CancellationToken cancellationToken)
        {
            return await _communicationInfoService.GetCommunicationInfoList(obj, cancellationToken);
        }

        [HttpGet("{Id}")]
        public async Task<CommunicationInfoDetailDTO> GetById([FromRoute] CommunicationInfoReadById obj, CancellationToken cancellationToken)
        {
            return await _communicationInfoService.GetCommunicationInfoById(obj, cancellationToken);
        }

        [HttpPost]
        public async Task<bool> Insert([FromBody] CommunicationInfoInsertCommand obj, CancellationToken cancellationToken)
        {
            return await _communicationInfoService.InsertCommunicationInfo(obj, cancellationToken);
        }

        [HttpPut]
        public async Task<bool> Update([FromBody] CommunicationInfoUpdateCommand obj, CancellationToken cancellationToken)
        {
            return await _communicationInfoService.UpdateCommunicationInfo(obj, cancellationToken);
        }

        [HttpDelete]
        public async Task<bool> UpdateIsDeleted([FromBody]CommunicationInfoUpdateIsDeletedCommand obj, CancellationToken cancellationToken)
        {
            return await _communicationInfoService.UpdateIsDeletedCommunicationInfo(obj, cancellationToken);
        }
    }
}
