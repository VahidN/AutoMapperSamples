using AutoMapper;
using Sample03.Models;

namespace Sample03.AutoMapperConfig
{
    public class TestProfile : Profile
    {
        protected override void Configure()
        {
            this.CreateMap<User, UserViewModel>()
                .ForMember(userViewModel => userViewModel.RegistrationDate,
                        opt => opt.ResolveUsing(src =>
                        {
                            var dt = src.RegistrationDate;
                            return dt.ToShamsiDateTime();
                        }));
        }
    }
}