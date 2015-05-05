using System.Collections.Generic;

namespace Sample04.Models
{
    public class User : BaseEntity
    {
        public string Name { set; get; }

        public virtual ICollection<Advertisement> Advertisements { get; set; }
    }
}