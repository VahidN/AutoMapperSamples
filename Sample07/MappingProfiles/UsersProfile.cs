using System.Data;
using AutoMapper;
using Sample07.Models;

namespace Sample07.MappingProfiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            this.CreateMap<IDataRecord, User>();
        }
    }
}