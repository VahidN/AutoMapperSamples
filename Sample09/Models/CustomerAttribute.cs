using System.Collections.Generic;

namespace Sample09.Models
{
    public class CustomerAttribute
    {
        public int Id { set; get; }
        public string Name { set; get; }

        public virtual ICollection<Customer> Customers { get; set; } // many-to-many relationship
    }
}