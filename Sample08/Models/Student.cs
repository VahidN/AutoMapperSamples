using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DelegateDecompiler;

namespace Sample08.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [StringLength(450)]
        public string LastName { get; set; }

        [Required]
        [StringLength(450)]
        public string FirstName { get; set; }

        [NotMapped]
        [Computed]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
    }
}