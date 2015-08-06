using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Sample12.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = "نام")]
        [StringLength(maximumLength: 10, MinimumLength = 3, ErrorMessage = "نام بايد حداقل 3 و حداكثر 10 حرف باشد")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = "نام خانوادگي")]
        [StringLength(maximumLength: 10, MinimumLength = 3, ErrorMessage = "نام خانوادگي بايد حداقل 3 و حداكثر 10 حرف باشد")]
        [AdditionalMetadata("Tooltip", "براي تست")]
        public string LastName { get; set; }
    }
}