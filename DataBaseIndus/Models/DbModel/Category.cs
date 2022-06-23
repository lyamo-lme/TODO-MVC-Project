using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models.DbModel
{
    public class Category
    {
        [Key]
        public int IdCategory { get; set; }=0;
        [Required(ErrorMessage = "Please enter category name")]
        public string NameCategory { get; set; }
        public List<TodoModel>? tasks { get; set; }

    }
}
