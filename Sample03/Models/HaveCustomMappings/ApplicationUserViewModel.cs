using AutoMapper;
using Sample03.AutoMapperConfig;

namespace Sample03.Models.HaveCustomMappings
{
    public class ApplicationUserViewModel : IHaveCustomMappings
    {
        public string UserName { get; set; }
        public string LastName { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<ApplicationUser, ApplicationUserViewModel>()
                  .ForMember(viewModel => viewModel.UserName,
                             opt => opt.MapFrom(applicationUser => applicationUser.Name));
        }
    }
}