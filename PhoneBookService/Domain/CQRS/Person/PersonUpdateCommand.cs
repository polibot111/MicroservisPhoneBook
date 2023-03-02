namespace PhoneBookService.Domain.CQRS.Person
{
    public class PersonUpdateCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
    }
}
