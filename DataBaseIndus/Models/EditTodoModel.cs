using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class EditTodoModel
    {
        [Key]
        public int Id { get; set; }
        public string NameTodo { get; set; }
        public DateTime? DeadLine { get; set; }
        public int CategoryId { get; set; }
        public bool TaskCompleted { get; set; }
    }
}
