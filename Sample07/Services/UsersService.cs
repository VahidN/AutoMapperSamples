using System.Collections.Generic;
using System.Data.SqlClient;
using AutoMapper;
using Sample07.Models;
using Sample07.Services.Contracts;

namespace Sample07.Services
{
    public class UsersService : AdoMapper<User>, IUsersService
    {
        public UsersService(string connectionString, IMapper mapper)
            : base(connectionString, mapper)
        {
        }

        public IEnumerable<User> GetAll()
        {
            using (var command = new SqlCommand("SELECT * FROM Users"))
            {
                return GetRecords(command);
            }
        }

        public User GetById(int id)
        {
            using (var command = new SqlCommand("SELECT * FROM Users WHERE Id = @id"))
            {
                command.Parameters.Add(new SqlParameter("id", id));
                return GetRecord(command);
            }
        }
    }
}