using PhoneBookService.Domain.CQRS.CommunicationInfo;
using PhoneBookService.Domain.DTO_s.CommunicationInfo;

namespace PhoneBookService.Interface.Services
{
    public interface ICommunicationInfoService
    {
        Task<List<CommunicationInfoDTO>> GetCommunicationInfoList(CommunicationInfoQuery obj, CancellationToken cancellationToken);
        Task<CommunicationInfoDetailDTO> GetCommunicationInfoById(CommunicationInfoReadById obj, CancellationToken cancellationToken);
        Task<bool> InsertCommunicationInfo(CommunicationInfoInsertCommand obj, CancellationToken cancellationToken);
        Task<bool> UpdateCommunicationInfo(CommunicationInfoUpdateCommand obj, CancellationToken cancellationToken);
        Task<bool> UpdateIsDeletedCommunicationInfo(CommunicationInfoUpdateIsDeletedCommand obj, CancellationToken cancellationToken);










    }
}
