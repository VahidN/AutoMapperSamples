using Sample03.AutoMapperConfig;

namespace Sample03.Models.AutoWire
{
    public class PersonViewModel : IMapFrom<Person>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}