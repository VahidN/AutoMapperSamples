using System.Collections.Generic;
using Sample11.Models;

namespace Sample11.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Address> Addresses { get; set; }
        public ICollection<Email> Emails { get; set; }
    }
}