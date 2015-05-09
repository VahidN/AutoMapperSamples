using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DelegateDecompiler;

namespace Sample09.Models
{
    public class Customer
    {
        public int Id { set; get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        [Computed]
        [NotMapped]
        public string FullName
        {
            get { return FirstName + ' ' + LastName; }
        }
    }
}