using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class CreateTask
    {
        [Required(ErrorMessage = "Please enter name task")]
        public string NameTask { get; set; }
        public DateTime? DeadLine { get; set; }
        [Required(ErrorMessage = "Please enter Category")]
        public int CategoryId { get; set; }
        public bool TaskCompleted { get; set; } = false;
    }
}
