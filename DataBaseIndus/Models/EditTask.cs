using System.ComponentModel.DataAnnotations;

namespace DataBaseIndus.Models
{
    public class EditTask
    {
        [Key]
        public int Id { get; set; }
        public string NameTask { get; set; }
        public DateTime? DeadLine { get; set; }
        public int CategoryId { get; set; }
        public bool TaskCompleted { get; set; }
    }
}
