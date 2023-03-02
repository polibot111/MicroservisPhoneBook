using PhoneBookService.Domain.Abstract;

namespace PhoneBookService.Domain.Entities
{
    public class CommunicationInfo : BaseEntity
    {
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Content { get; set; }
        public Person Person { get; set; }
        public Guid PersonId { get; set; }
    }
}
