using System;
using System.Configuration;
using System.Threading;
using Sample07.Services;
using Sample07.Services.Contracts;
using StructureMap;

namespace Sample07.IoCConfig
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
                var connection1 = ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString;

                cfg.For<IUsersService>().Use<UsersService>()
                    .Ctor<string>("connectionString").Is(connection1);

                cfg.For<IAdvertisementsService>().Use<AdvertisementsService>()
                    .Ctor<string>("connectionString").Is(connection1);

                cfg.Scan(scan =>
                {
                    scan.AssemblyContainingType<IUsersService>(); // for other asms, if any.
                    scan.WithDefaultConventions();
                });
            });
            return container;
        }
    }
}