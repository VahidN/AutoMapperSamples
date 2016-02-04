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
        private readonly IMapper _mapper;

        public UsersService(IMapper mapper)
        {
            _mapper = mapper;
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
            _mapper.Map(source: dbUser1, destination: uiUser);
            return uiUser;
        }

        public IList<UserViewModel> GetUsersList()
        {
            var users = new List<User>();
            for (var i = 0; i < 100; i++)
            {
                users.Add(new User
                {
                    Id = i + 1,
                    Name = string.Format("Test {0}", i),
                    RegistrationDate = DateTime.Now.AddDays(-10)
                });
            }

            return users.AsQueryable()
                        .ProjectTo<UserViewModel>(parameters: null, configuration: _mapper.ConfigurationProvider)
                        .ToList();
        }
    }
}
