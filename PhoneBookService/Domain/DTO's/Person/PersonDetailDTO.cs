using PhoneBookService.Domain.DTO_s.CommunicationInfo;

namespace PhoneBookService.Domain.DTO_s.Person
{
    public class PersonDetailDTO
    {
        public PersonDetailDTO()
        {
            Communications = new();
        }
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Surname{ get; set; }
        public string Company{ get; set; }
        public List<CommunicationInfoDTO> Communications{ get; set; }
    }
}
