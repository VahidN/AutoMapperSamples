using AutoMapper;

namespace Sample03.AutoMapperConfig
{
    public interface IMapFrom<T>
    {

    }

    public interface IHaveCustomMappings
    {
        void CreateMappings(IConfiguration configuration);
    }
}