using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRDUASPProject.Models
{
    public class Book
    {
        [Required]
        [StringLength(100)]
        [DisplayName("Book Name")]
        public string Name { get; set; }
        [Key]
        [Range(0, 100, ErrorMessage ="Enter an id between 1 and 100")]
        public string id { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
    }
}
