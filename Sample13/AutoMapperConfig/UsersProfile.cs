using AutoMapper;
using Sample13.Models;
using Sample13.ViewModels;

namespace Sample13.AutoMapperConfig
{
    public class UsersProfile : Profile
    {
        protected override void Configure()
        {
            string userIdentityName = null;
            this.CreateMap<UserModel, UserViewModel>()
                .ForMember(d => d.UserIdentityName, opt => opt.MapFrom(src => userIdentityName));
        }
    }
}