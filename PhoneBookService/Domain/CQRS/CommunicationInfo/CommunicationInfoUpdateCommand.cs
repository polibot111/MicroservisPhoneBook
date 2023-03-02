namespace PhoneBookService.Domain.CQRS.CommunicationInfo
{
    public class CommunicationInfoUpdateCommand
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Content { get; set; }
    }
}
