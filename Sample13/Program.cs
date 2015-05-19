using System;
using System.Collections.Generic;
using System.Linq;
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
            Mappings.RegisterMappings();

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
                               .Project()
                               .To<UserViewModel>(new { userIdentityName = "User.Identity.Name Value Here" })
                               .ToList();

            foreach (var user in uiUsers)
            {
                Console.WriteLine(user.FirstName);
            }
        }
    }
}