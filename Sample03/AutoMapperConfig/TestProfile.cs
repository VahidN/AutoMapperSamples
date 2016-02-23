using AutoMapper;
using Sample03.Models;

namespace Sample03.AutoMapperConfig
{
    public class TestProfile : Profile
    {
        protected override void Configure()
        {
            this.CreateMap<User, UserViewModel>()
                .ProjectUsing(src => new UserViewModel
                {
                    Id = src.Id,
                    Name = src.Name,
                    RegistrationDate = src.RegistrationDate.ToShamsiDateTime()
                });
        }
    }
}