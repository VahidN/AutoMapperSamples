using System.Collections.Generic;
using Sample07.Models;

namespace Sample07.Services.Contracts
{
    public interface IUsersService
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}