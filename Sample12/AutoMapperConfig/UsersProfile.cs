using AutoMapper;
using Sample12.Models;
using Sample12.ViewModels;

namespace Sample12.AutoMapperConfig
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            this.CreateMap<UserModel, UserViewModel>();
        }
    }
}