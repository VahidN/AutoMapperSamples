using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Sample14
{
    public class PersonList
    {
        readonly List<Person> _list = new List<Person>();
        public ReadOnlyCollection<Person> GetPersons()
        {
            if (!_list.Any())
            {
                for (int i = 0; i < 100 * 1000; i++)
                {
                    _list.Add(new Person(i + 1, "Person Name" + i, "Person Family" + i, (PersonType)(i % 2)));
                }

            }
            return _list.AsReadOnly();
        }
    }
}
