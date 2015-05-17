using AutoMapper;

namespace Sample12.AutoMapperConfig
{
    public static class Mappings
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg => // In Application_Start()
            {
                cfg.AddProfile<UsersProfile>();
            });
            Mapper.AssertConfigurationIsValid();
        }
    }
}