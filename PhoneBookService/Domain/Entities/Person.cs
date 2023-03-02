using PhoneBookService.Domain.Abstract;

namespace PhoneBookService.Domain.Entities
{
    public class Person : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public ICollection<CommunicationInfo> CommunicationInfos { get; set; }
    }
}
