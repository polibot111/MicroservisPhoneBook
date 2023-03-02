using PhoneBookService.Domain.CQRS.CommunicationInfo;
using PhoneBookService.Domain.DTO_s.CommunicationInfo;
using PhoneBookService.Interface.Repositories;
using PhoneBookService.Interface.Services;

namespace PhoneBookService.Services
{
    public class CommunicationInfoService : ICommunicationInfoService
    {
        readonly ICommunicationInfoReadRepository _communicationInfoReadRepository;
        readonly ICommunicationInfoWriteRepository _communicationInfoWriteRepository;
        readonly IPersonReadRepository _personReadRepository;

        public CommunicationInfoService(ICommunicationInfoReadRepository communicationInfoReadRepository, ICommunicationInfoWriteRepository communicationInfoWriteRepository, IPersonReadRepository personReadRepository)
        {
            _communicationInfoReadRepository = communicationInfoReadRepository;
            _communicationInfoWriteRepository = communicationInfoWriteRepository;
            _personReadRepository = personReadRepository;
        }

        public async Task<List<CommunicationInfoDTO>> GetCommunicationInfoList(CommunicationInfoQuery obj, CancellationToken cancellationToken)
        {
            var person = await _personReadRepository.GetByIdAsync(cancellationToken, obj.PersonId);
            var communicationInfos = (await _communicationInfoReadRepository.GetAllAsync(cancellationToken)).Where(x => x.Person == person).Select(p => new CommunicationInfoDTO()
            {
                Id = p.Id,
                PhoneNumber = p.PhoneNumber,
                Address = p.Address,
                Mail = p.Mail,
                Content = p.Content,
                Latitude = p.Latitude,
                Longitude = p.Longitude

            }).ToList();

            return communicationInfos;
        }

        public async Task<CommunicationInfoDetailDTO> GetCommunicationInfoById(CommunicationInfoReadById obj, CancellationToken cancellationToken)
        {
            var communicationInfo = await _communicationInfoReadRepository.GetByIdAsync(cancellationToken, obj.Id);
            return new CommunicationInfoDetailDTO
            {
                Id = communicationInfo.Id,
                PhoneNumber = communicationInfo.PhoneNumber,
                Address = communicationInfo.Address,
                Mail = communicationInfo.Mail,
                Content = communicationInfo.Content,
                Latitude = communicationInfo.Latitude,
                Longitude = communicationInfo.Longitude,
                PersonId = communicationInfo.PersonId,
            };
        }

        public async Task<bool> InsertCommunicationInfo(CommunicationInfoInsertCommand obj, CancellationToken cancellationToken)
        {
            try
            {
                var person = await _personReadRepository.GetByIdAsync(cancellationToken, obj.PersonId);
                var result = await _communicationInfoWriteRepository.AddAsync(new()
                {
                    Id = Guid.NewGuid(),
                    PhoneNumber = obj.PhoneNumber,
                    Address = obj.Address,
                    Mail = obj.Mail,
                    Content = obj.Content,
                    Latitude = obj.Latitude,
                    Longitude = obj.Longitude,
                    Person = person

                }, cancellationToken);

                await _communicationInfoWriteRepository.SaveAsync(cancellationToken);

                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }

        }

        public async Task<bool> UpdateCommunicationInfo(CommunicationInfoUpdateCommand obj, CancellationToken cancellationToken)
        {
            try
            {
                var communicationInfo = await _communicationInfoReadRepository.GetByIdAsync(cancellationToken, obj.Id);

                communicationInfo.PhoneNumber = obj.PhoneNumber;
                communicationInfo.Address = obj.Address;
                communicationInfo.Mail = obj.Mail;
                communicationInfo.Content = obj.Content;
                communicationInfo.Latitude = obj.Latitude;
                communicationInfo.Longitude = obj.Longitude;


                await _communicationInfoWriteRepository.SaveAsync(cancellationToken);

                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }

        }


        public async Task<bool> UpdateIsDeletedCommunicationInfo(CommunicationInfoUpdateIsDeletedCommand obj, CancellationToken cancellationToken)
        {
            try
            {
                var communicationInfo = await _communicationInfoReadRepository.GetByIdAsync(cancellationToken, obj.Id);
                communicationInfo.IsDeleted = true;

                await _communicationInfoWriteRepository.SaveAsync(cancellationToken);

                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }

        }
    }
}
