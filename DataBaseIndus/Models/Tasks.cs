using System.ComponentModel.DataAnnotations;
namespace DataBaseIndus.Models
{
    public class Tasks
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please name")]
        public string NameTask { get; set; }
        public DateTime? DeadLine { get; set; }
       
        public int CategoryId { get; set; }
        public int TaskCompleted { get; set; }=0;
        public virtual Category category { get; set; }
    } 
}
