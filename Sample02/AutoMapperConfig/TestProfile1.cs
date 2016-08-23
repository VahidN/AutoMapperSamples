using System;
using AutoMapper;
using Sample02.Models;

namespace Sample02.AutoMapperConfig
{
    public class TestProfile1 : Profile
    {
        public TestProfile1()
        {
            // اين تنظيم سراسري هست و به تمام خواص زماني اعمال مي‌شود
            this.CreateMap<DateTime, string>().ConvertUsing(new DateTimeToPersianDateTimeConverter());

            this.CreateMap<User, UserViewModel>();

            // اين تنظيم سفارشي‌تر است
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