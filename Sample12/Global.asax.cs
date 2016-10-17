using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using Sample12.AutoMapperConfig;
using Sample12.AutoMapperConfig.AttributeMapping;

namespace Sample12
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);


            Mappings.RegisterMappings();
            ModelMetadataProviders.Current = new MappedMetadataProvider(Mapper.Configuration);

            var modelValidatorProvider = ModelValidatorProviders.Providers
                .Single(provider => provider is DataAnnotationsModelValidatorProvider);
            ModelValidatorProviders.Providers.Remove(modelValidatorProvider);
            ModelValidatorProviders.Providers.Add(new MappedValidatorProvider(Mapper.Configuration));
        }
    }
}