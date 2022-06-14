using ToDoList.Models.DbModel;

namespace ToDoList.Data
{
    public interface ICategoryRepository
    {
        Category CreateCategory(Category model);
        List<Category> GetCategories();
        Category GetCategoryTasks(int id);
        Category GetCategoryById(int id);
        Category EditCategory(Category model) ;
        int DeleteCategory(int id);
    }
}