using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class AddTask
    {
        [Required(ErrorMessage = "Please enter name task")]
        public string NameTask { get; set; }
        public DateTime? DeadLine { get; set; }
        [Required(ErrorMessage = "Please enter Category")]
        public int CategoryId { get; set; }
        public bool TaskCompleted { get; set; } = false;
        public bool IsValid() {
            if (string.IsNullOrEmpty(NameTask))
            {
                return false;
            }
            if (CategoryId==0||CategoryId<0) {
                return false;
            }
            return true;
        }
    }
}
