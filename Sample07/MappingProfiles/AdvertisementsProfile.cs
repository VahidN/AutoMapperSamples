using System.Data;
using AutoMapper;
using Sample07.Models;

namespace Sample07.MappingProfiles
{
    public class AdvertisementsProfile : Profile
    {
        protected override void Configure()
        {
            this.CreateMap<IDataRecord, Advertisement>()
                .ForMember(dest => dest.TitleWithOtherName,
                           options => options.MapFrom(src =>
                                src.GetString(src.GetOrdinal("Title"))));
        }
    }
}