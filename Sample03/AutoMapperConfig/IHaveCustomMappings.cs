using AutoMapper;

namespace Sample03.AutoMapperConfig
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}