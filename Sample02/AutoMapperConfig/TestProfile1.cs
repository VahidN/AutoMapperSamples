using System;
using AutoMapper;
using Sample02.Models;

namespace Sample02.AutoMapperConfig
{
    public class TestProfile1 : Profile
    {
        protected override void Configure()
        {
            // «Ì‰  ‰ŸÌ„ ”—«”—Ì Â”  Ê »Â  „«„ ŒÊ«’ “„«‰Ì «⁄„«· „Ìù‘Êœ
            this.CreateMap<DateTime, string>().ConvertUsing(new DateTimeToPersianDateTimeConverter());

            this.CreateMap<User, UserViewModel>();

            // «Ì‰  ‰ŸÌ„ ”›«—‘Ìù — «” 
            /*this.CreateMap<User, UserViewModel>()
             .ForMember(userViewModel => userViewModel.RegistrationDate,
                        opt => opt.ResolveUsing(src =>
                        {
                             var dt = src.RegistrationDate;
                             return dt.ToShortDateString();
                        }));*/
        }
    }
}