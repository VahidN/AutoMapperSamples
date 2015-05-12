using System.Collections.Generic;

namespace Sample11.Models
{
    public class SiteUser
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
    }
}