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

                scan.AssemblyContainingType(typeof(IMapFrom<>));
                scan.ConnectImplementationsToTypesClosing(typeof(IMapFrom<>));
            });

            this.For<MapperConfiguration>().Singleton().Use("MapperConfig", ctx =>
             {
                 var config = new MapperConfiguration(cfg =>
                 {
                     cfg.CreateMissingTypeMaps = true; // It will connect all of the IMapFrom<>'s automatically.
                     addAllCustomAutoMapperProfiles(ctx, cfg);
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
    }
}