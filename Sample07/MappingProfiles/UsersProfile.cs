using System.Data;
using AutoMapper;
using Sample07.Models;

namespace Sample07.MappingProfiles
{
    public class UsersProfile : Profile
    {
        protected override void Configure()
        {
            this.CreateMap<IDataRecord, User>();
        }
    }
}