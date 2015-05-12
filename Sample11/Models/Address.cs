using System.ComponentModel.DataAnnotations.Schema;

namespace Sample11.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Text { get; set; }

        [ForeignKey("SiteUserId")]
        public virtual SiteUser SiteUser { get; set; }
        public int SiteUserId { get; set; }
    }
}