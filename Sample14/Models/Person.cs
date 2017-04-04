namespace Sample14
{
    public class Person
    {
        public long PersonId { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public PersonType PersonType { get; set; }

        public Person(long personId, string name, string family, PersonType personType)
        {
            PersonId = personId;
            Name = name;
            Family = family;
            PersonType = personType;
        }
    }
}