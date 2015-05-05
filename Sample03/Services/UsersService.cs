using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Sample03.Models;

namespace Sample03.Services
{
    public class UsersService : IUsersService
    {
        private readonly IMappingEngine _mappingEngine;

        public UsersService(IMappingEngine mappingEngine)
        {
            _mappingEngine = mappingEngine;
        }

        public UserViewModel GetName(int id)
        {
            var dbUser1 = new User
            {
                Id = 1,
                Name = "Test",
                RegistrationDate = DateTime.Now.AddDays(-10)
            };

            var uiUser = new UserViewModel();
            _mappingEngine.Map(source: dbUser1, destination: uiUser);
            return uiUser;
        }

        public IList<UserViewModel> GetUsersList()
        {
            var users = new List<User>();
            for (var i = 0; i < 100; i++)
            {
                users.Add(new User
                {
                    Id = i+1,
                    Name = "Test " + i,
                    RegistrationDate = DateTime.Now.AddDays(-10)
                });
            }

            return users.AsQueryable().Project(_mappingEngine).To<UserViewModel>().ToList();
        }
    }
}
