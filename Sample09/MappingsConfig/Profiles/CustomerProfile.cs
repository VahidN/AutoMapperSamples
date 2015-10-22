using AutoMapper;
using Sample09.Models;
using Sample09.ViewModels;

namespace Sample09.MappingsConfig.Profiles
{
    public class CustomerProfile : Profile
    {
        protected override void Configure()
        {
            this.CreateMap<Customer, CustomerViewModel>()
             .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(entity => entity.FullName))
             .ForMember(dest => dest.Bio, opt => opt.MapFrom(entity => entity.Bio ?? "N/A"));
            // opt.NullSubstitute doesn't work here
        }
    }
}