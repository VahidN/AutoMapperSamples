using AutoMapper;
using System.Linq;
using Sample09.Models;
using Sample09.ViewModels;

namespace Sample09.MappingsConfig.Profiles
{
    public class OrderProfile : Profile
    {
        protected override void Configure()
        {
            this.CreateMap<Order, NumberOfOrderViewModel>()
               .ForMember(dest => dest.NumberOfOrders,
                    opt => opt.MapFrom(src => "Number of Order(s): " + src.OrderItems.Count()))
               .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.FullName));

            this.CreateMap<Order, OrderShipViewModel>()
                .ForMember(dest => dest.ShipHome, opt => opt.MapFrom(src=>src.ShipToHomeAddress? "Yes": "No"))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.FullName));

            this.CreateMap<Order, OrderDateViewModel>()
            .ForMember(dest => dest.PurchaseHour, opt => opt.MapFrom(src => src.PurchaseDate.Hour))
            .ForMember(dest => dest.PurchaseMinute, opt => opt.MapFrom(src => src.PurchaseDate.Minute))
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.FullName));

            this.CreateMap<Order, OrderViewModel>()
               .ForMember(dest => dest.OrderNumber, opt => opt.MapFrom(src => src.OrderNo))
               //.ForMember(dest => dest.OrderItems, opt => opt.Ignore())
               .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.FullName));
        }
    }
}