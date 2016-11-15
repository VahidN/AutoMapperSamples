using System.Collections.Generic;
using Sample03.Models;
using Sample03.Models.AutoWire;
using Sample03.Models.HaveCustomMappings;

namespace Sample03.Services
{
    public interface IUsersService
    {
        UserViewModel GetName(int id);
        IList<UserViewModel> GetUsersList();
        IList<PersonViewModel> GetPeopleList();
        IList<ApplicationUserViewModel> GetApplicationUsersList();
    }
}