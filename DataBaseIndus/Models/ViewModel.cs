namespace DataBaseIndus.Models
{
    public class ViewModel
    {
        public Tasks Task { get; set; }
        public Category Category { get; set; }
        public EditTask EditModel { get; set; }
        public AddTask Addtask { get; set; }
        public List<Tasks> tasks = new List<Tasks>();
        public List<Category> Categories= new List<Category>();
    }
}
