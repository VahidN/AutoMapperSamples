using AutoMapper;
using Sample09.Models;
using Sample09.ViewModels;

namespace Sample09.MappingsConfig.Profiles
{
    public class OrderItemsProfile: Profile
    {
        protected override void Configure()
        {
            this.CreateMap<OrderItem, OrderItemsViewModel>();
        }

        public override string ProfileName
        {
            get { return this.GetType().Name; }
        }
    }
}