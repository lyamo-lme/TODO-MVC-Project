using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class CreateTodoModel
    {
        [Required(ErrorMessage = "Please enter name task")]
        public string NameTodo { get; set; }
        public DateTime? DeadLine { get; set; }
        public int? CategoryId { get; set; } 
        public bool TaskCompleted { get; set; } = false;
    }
}
