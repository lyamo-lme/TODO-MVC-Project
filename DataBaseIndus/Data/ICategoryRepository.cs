using ToDoList.Models;

namespace ToDoList.Data
{
    public interface ICategoryRepository
    {
        void AddCategory(AddCategory model);
        List<Category> GetCategories();
        Category GetCategoryTasks(int id);
        Category GetCategoryById(int id);
        void EditCategory(Category model) ;
        void DeleteCategory(int id);
    }
}