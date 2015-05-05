using System;
using AutoMapper;
using AutoMapper.Mappers;
using Sample02.AutoMapperConfig;
using Sample02.Models;

namespace Sample02
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbUser1 = new User
            {
                Id = 1,
                Name = "Test",
                RegistrationDate = DateTime.Now.AddDays(-10)
            };

            var uiUser = new UserViewModel();

            usingGlobalConfig(dbUser1, uiUser);
            usingSpecificEngine(dbUser1, uiUser);
        }

        private static void usingSpecificEngine(User dbUser1, UserViewModel uiUser)
        {
            var configurationStore = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
            configurationStore.AddProfile<TestProfile1>();
            var mappingEngine = new MappingEngine(configurationStore);
            mappingEngine.ConfigurationProvider.AssertConfigurationIsValid();

            mappingEngine.Map(source: dbUser1, destination: uiUser);
            Console.WriteLine("RegistrationDate: {0}", uiUser.RegistrationDate);
        }

        private static void usingGlobalConfig(User dbUser1, UserViewModel uiUser)
        {
            Mapper.Initialize(cfg => // In Application_Start()
            {
                cfg.AddProfile<TestProfile1>();
                cfg.AddProfile<TestProfile2>();
            });
            Mapper.Map(source: dbUser1, destination: uiUser);
            Mapper.AssertConfigurationIsValid();

            Console.WriteLine("RegistrationDate: {0}", uiUser.RegistrationDate);
        }
    }
}