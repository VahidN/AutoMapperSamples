using System.Collections.Generic;
using System.Data.SqlClient;
using AutoMapper;
using Sample07.Models;
using Sample07.Services.Contracts;

namespace Sample07.Services
{
    public class AdvertisementsService : AdoMapper<Advertisement>, IAdvertisementsService
    {
        public AdvertisementsService(string connectionString, IMapper mapper)
            : base(connectionString, mapper)
        {
        }

        public IEnumerable<Advertisement> GetAll()
        {
            using (var command = new SqlCommand("SELECT * FROM Advertisements"))
            {
                return GetRecords(command);
            }
        }

        public Advertisement GetById(int id)
        {
            using (var command = new SqlCommand("SELECT * FROM Advertisements WHERE Id = @id"))
            {
                command.Parameters.Add(new SqlParameter("id", id));
                return GetRecord(command);
            }
        }
    }
}