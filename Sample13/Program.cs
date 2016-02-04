using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Sample13.AutoMapperConfig;
using Sample13.Models;
using Sample13.ViewModels;

namespace Sample13
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg => // In Application_Start()
            {
                cfg.AddProfile<UsersProfile>();
            });
            config.AssertConfigurationIsValid();

            var mapper = config.CreateMapper();

            var users = new List<UserModel>
            {
                new UserModel
                {
                    FirstName = "f1",
                    LastName = "l1"
                },
                new UserModel
                {
                    FirstName = "و",
                    LastName = "ن"
                }
            };


            var uiUsers = users.AsQueryable()
                .ProjectTo<UserViewModel>(parameters: new { userIdentityName = "User.Identity.Name Value Here" },
                                          configuration: mapper.ConfigurationProvider)
                               .ToList();

            foreach (var user in uiUsers)
            {
                Console.WriteLine(user.FirstName);
            }
        }
    }
}