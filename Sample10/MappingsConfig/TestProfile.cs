using System.Linq;
using AutoMapper;
using Sample10.Models;
using Sample10.ViewModels;

namespace Sample10.MappingsConfig
{
    public class TestProfile : Profile
    {
        protected override void Configure()
        {
            this.CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.CustomName,
                           opt => opt.MapFrom(src => src.Name + "[" + src.Age + "]"))
                 .ForMember(dest => dest.PostsCount,
                            opt => opt.MapFrom(src => src.BlogPosts.Count()));
        }

        public override string ProfileName
        {
            get { return this.GetType().Name; }
        }
    }
}