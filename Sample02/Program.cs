using System;
using AutoMapper;
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

            usingLocalConfig(dbUser1, uiUser);
        }

        /// <summary>
        /// AutoMapper 4.2+ uses non-static API. So its config is always local and specific.
        /// </summary>
        private static void usingLocalConfig(User dbUser1, UserViewModel uiUser)
        {
            var config = new MapperConfiguration(cfg => // In Application_Start()
            {
                cfg.AddProfile<TestProfile1>();
                cfg.AddProfile<TestProfile2>();
            });
            config.AssertConfigurationIsValid();

            var mapper = config.CreateMapper();
            mapper.Map(source: dbUser1, destination: uiUser);

            Console.WriteLine("RegistrationDate: {0}", uiUser.RegistrationDate);
        }
    }
}