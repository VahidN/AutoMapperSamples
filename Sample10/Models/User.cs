using System.Collections.Generic;

namespace Sample10.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public virtual ICollection<BlogPost> BlogPosts { get; set; }
    }
}