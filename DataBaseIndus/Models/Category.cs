using System.ComponentModel.DataAnnotations;

namespace DataBaseIndus.Models
{
    public class Category
    {
        [Key]
        public int IdCategory { get; set; }
        [Required(ErrorMessage = "Please enter category name")]
        public string NameCategory { get; set; }
        public List<Tasks>? tasks { get; set; }

    }
}
