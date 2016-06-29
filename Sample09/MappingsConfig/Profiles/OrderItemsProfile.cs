using AutoMapper;
using Sample09.Models;
using Sample09.ViewModels;

namespace Sample09.MappingsConfig.Profiles
{
    public class OrderItemsProfile: Profile
    {
        public OrderItemsProfile()
        {
            this.CreateMap<OrderItem, OrderItemsViewModel>();
        }
    }
}