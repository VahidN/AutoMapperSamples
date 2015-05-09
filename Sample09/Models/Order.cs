using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using DelegateDecompiler;

namespace Sample09.Models
{
    public class Order
    {
        public int Id { set; get; }
        public string OrderNo { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool ShipToHomeAddress { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
        public int CustomerId { get; set; }

        [Computed]
        [NotMapped]
        public decimal Total
        {
            get { return OrderItems.Sum(x => x.TotalPrice); }
        }
    }
}