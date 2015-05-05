using System;
using AutoMapper;
using Sample02.Models;

namespace Sample02.AutoMapperConfig
{
    public class TestProfile2 : Profile
    {
        protected override void Configure()
        {
            // type maps are still global.
            // اين تنظيم سراسري هست و به تمام خواص زماني اعمال مي‌شود
            this.CreateMap<DateTime, string>().ConvertUsing(new StringFromDateTimeTypeConverter());
            this.CreateMap<User, UserViewModel>();
        }

        public override string ProfileName
        {
            get { return this.GetType().Name; }
        }
    }
}