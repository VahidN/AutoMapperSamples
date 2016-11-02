using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Sample09.Models;
using Sample09.ViewModels;

namespace Sample09.MappingsConfig.Profiles
{
    public class CustomerAttributeProfile : Profile
    {
        public CustomerAttributeProfile()
        {
            this.CreateMap<ICollection<Customer>, ICollection<CustomerAttributeViewModel>>()
                .ConvertUsing<CustomerListConverter>();
        }
    }

    /// <summary>
    /// How to flatten nested collections
    /// </summary>
    public class CustomerListConverter : ITypeConverter<ICollection<Customer>, ICollection<CustomerAttributeViewModel>>
    {
        public ICollection<CustomerAttributeViewModel> Convert(
            ICollection<Customer> source,
            ICollection<CustomerAttributeViewModel> destination,
            ResolutionContext context)
        {
            return source.SelectMany(customer => customer.CustomerAttributes.Select(attribute =>
                                                        new CustomerAttributeViewModel
                                                        {
                                                            AttributeName = attribute.Name,
                                                            CustomerName = customer.FullName
                                                        }))
                                    .ToList();
        }
    }
}