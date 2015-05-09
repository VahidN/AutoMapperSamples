using System.Collections.Generic;

namespace Sample09.ViewModels
{
    public class OrderViewModel
    {
        public string CustomerName { get; set; }
        public decimal Total { get; set; }
        public string OrderNumber { get; set; }
        public IEnumerable<OrderItemsViewModel> OrderItems { get; set; }
    }
}