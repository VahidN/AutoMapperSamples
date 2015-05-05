using System.ComponentModel.DataAnnotations.Schema;

namespace Sample04.Models
{
    public class Advertisement : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public int UserId { get; set; }
    }
}