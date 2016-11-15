using System.Linq;
using AutoMapper;
using Sample03.AutoMapperConfig;
using StructureMap;

namespace Sample03.IoCConfig
{
    public class AutoMapperRegistry : Registry
    {
        public AutoMapperRegistry()
        {
            this.Scan(scan =>
            {
                scan.TheCallingAssembly();
                //scan.AssemblyContainingType<SomeType>(); // for other asms, if any.
                scan.WithDefaultConventions();

                scan.AddAllTypesOf<Profile>().NameBy(item => item.FullName);
                scan.AddAllTypesOf<IHaveCustomMappings>().NameBy(item => item.FullName);
            });

            this.For<MapperConfiguration>().Singleton().Use("MapperConfig", ctx =>
             {
                 var config = new MapperConfiguration(cfg =>
                 {
                     cfg.CreateMissingTypeMaps = true; // It will connect `Person` & `PersonViewModel` automatically.
                     addAllCustomAutoMapperProfiles(ctx, cfg);
                     addAllIHaveCustomMappings(ctx, cfg);
                 });
                 config.AssertConfigurationIsValid();

                 return config;
             });

            this.For<IMapper>().Singleton().Use(ctx => ctx.GetInstance<MapperConfiguration>().CreateMapper(ctx.GetInstance));
        }

        private static void addAllCustomAutoMapperProfiles(IContext ctx, IMapperConfigurationExpression cfg)
        {
            var profiles = ctx.GetAllInstances<Profile>().ToList();
            foreach (var profile in profiles)
            {
                cfg.AddProfile(profile);
            }
        }

        private void addAllIHaveCustomMappings(IContext ctx, IMapperConfigurationExpression cfg)
        {
            var profiles = ctx.GetAllInstances<IHaveCustomMappings>().ToList();
            foreach (var profile in profiles)
            {
                profile.CreateMappings(cfg);
            }
        }
    }
}