using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models.DbModel
{
    public class TodoModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please name")]
        public string NameTodo { get; set; }
        public DateTime? DeadLine { get; set; }
        public int CategoryId { get; set; }
        public bool TaskCompleted { get; set; } = false;
        public virtual string? NameCategory { get; set; }
    }
}
