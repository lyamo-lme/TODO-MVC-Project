using ToDoList.Models.DbModel;

namespace ToDoList.Models
{
    public class ViewModel
    {
        public TodoModel Task { get; set; }
        public Category Category { get; set; }
        public CategoryViewModel CategoryViewModel { get; set; }
        public EditTodoModel EditModel { get; set; }
        public CreateTodoModel CreateTask { get; set; }
        public List<TodoModel> Tasks = new List<TodoModel>();
        public List<Category> Categories= new List<Category>();
        public List<CategoryViewModel> categoryViewModels = new List<CategoryViewModel>();

        
    }
}
