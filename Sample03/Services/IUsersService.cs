using System.Collections.Generic;
using Sample03.Models;

namespace Sample03.Services
{
    public interface IUsersService
    {
        UserViewModel GetName(int id);
        IList<UserViewModel> GetUsersList();
    }
}