using System.ComponentModel.DataAnnotations.Schema;
using DelegateDecompiler;

namespace Sample09.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
        public int OrderId { get; set; }

        [Computed]
        [NotMapped]
        public decimal TotalPrice
        {
            get { return Price * Quantity; }
        }
    }
}