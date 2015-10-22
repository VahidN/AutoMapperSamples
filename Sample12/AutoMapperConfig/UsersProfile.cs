using AutoMapper;
using Sample12.Models;
using Sample12.ViewModels;

namespace Sample12.AutoMapperConfig
{
    public class UsersProfile : Profile
    {
        protected override void Configure()
        {
            this.CreateMap<UserModel, UserViewModel>();
        }
    }
}