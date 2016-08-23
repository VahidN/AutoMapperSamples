using System;
using System.Threading;
using AutoMapper;
using StructureMap;

namespace Sample03.IoCConfig
{
    public static class SmObjectFactory
    {
        private static readonly Lazy<Container> _containerBuilder =
            new Lazy<Container>(defaultContainer, LazyThreadSafetyMode.ExecutionAndPublication);

        public static IContainer Container
        {
            get { return _containerBuilder.Value; }
        }

        private static Container defaultContainer()
        {
            var container = new Container(cfg =>
            {
                cfg.AddRegistry<AutoMapperRegistry>();
                cfg.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    //scan.AssemblyContainingType<SomeType>(); // for other asms, if any.
                    scan.WithDefaultConventions();
                    scan.AddAllTypesOf<Profile>().NameBy(item => item.FullName);
                });
            });

            configureAutoMapper(container);

            return container;
        }

        private static void configureAutoMapper(IContainer container)
        {
            container.GetInstance<IMapper>().ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}