using System.Collections.Generic;
using System.Collections.ObjectModel;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sample14
{
    [TestClass]
    public class UnitTests
    {
        private static ReadOnlyCollection<Person> _persons;

        [AssemblyInitialize]
        public static void Initialize(TestContext context)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Person, PersonDto>();
            });
            Mapper.AssertConfigurationIsValid();

            _persons = new PersonList().GetPersons();
        }

        [TestMethod]
        public void FillPersonDtoList_UsingAutoMapper()
        {
            // act
            var personDtoList = Mapper.Map<List<PersonDto>>(_persons);

            //assert
            Assert.AreEqual(_persons.Count, personDtoList.Count);
        }

        [TestMethod]
        public void FillPersonDtoList_UsingHandlyAssignment()
        {
            // act
            var personDtoList = new List<PersonDto>();
            foreach (var person in _persons)
            {
                personDtoList.Add(new PersonDto(person.PersonId, person.Name, person.Family, person.PersonType));
            }

            //assert
            Assert.AreEqual(_persons.Count, personDtoList.Count);
        }
    }
}