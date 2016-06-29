using AutoMapper;
using Sample03.Models;

namespace Sample03.AutoMapperConfig
{
    public class TestProfile : Profile
    {
        public TestProfile()
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