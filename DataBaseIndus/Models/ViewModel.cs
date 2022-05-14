namespace ToDoList.Models
{
    public class ViewModel
    {
        public Tasks Task { get; set; }
        public Category Category { get; set; }
        public EditTask EditModel { get; set; }
        public AddTask AddTask { get; set; }
        public List<Tasks> Tasks = new List<Tasks>();
        public List<Category> Categories= new List<Category>();
    }
}
