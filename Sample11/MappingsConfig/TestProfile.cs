using AutoMapper;
using Sample11.Models;
using Sample11.ViewModels;

namespace Sample11.MappingsConfig
{
    public class TestProfile : Profile
    {
        protected override void Configure()
        {
            this.CreateMap<SiteUser, UserViewModel>()
                    .ForMember(dest => dest.Addresses, opt => opt.ExplicitExpansion())
                    .ForMember(dest => dest.Emails, opt => opt.ExplicitExpansion());
        }

        public override string ProfileName
        {
            get { return this.GetType().Name; }
        }
    }
}