namespace PhoneBookService.Domain.CQRS.Person
{
    public class PersonInsertCommand
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }

    }
}
