using DataBaseIndus.Models.DbModel;

namespace ToDoList.Models
{
    public class ViewModel
    {
        public Tasks Task { get; set; }
        public Category Category { get; set; }
        public CategoryViewModel CategoryViewModel { get; set; }
        public EditTask EditModel { get; set; }
        public CreateTask CreateTask { get; set; }
        public List<Tasks> Tasks = new List<Tasks>();
        public List<Category> Categories= new List<Category>();
        public List<CategoryViewModel> categoryViewModels = new List<CategoryViewModel>();
    }
}
