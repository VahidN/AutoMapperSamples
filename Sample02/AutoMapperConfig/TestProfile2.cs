using System;
using AutoMapper;
using Sample02.Models;

namespace Sample02.AutoMapperConfig
{
    public class TestProfile2 : Profile
    {
        public TestProfile2()
        {
            // type maps are still global.
            // اين تنظيم سراسري هست و به تمام خواص زماني اعمال مي‌شود
            this.CreateMap<DateTime, string>().ConvertUsing(new StringFromDateTimeTypeConverter());
            this.CreateMap<User, UserViewModel>();
        }
    }
}