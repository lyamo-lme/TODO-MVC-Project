using ToDoList.Models.DbModel;

namespace ToDoList.Data
{
    public interface ICategoryRepository
    {
        Task<Category> CreateCategory(Category model);
        Task<List<Category>> GetCategories();
        Task<Category> GetCategoryTasks(int id);
        Task<Category> GetCategoryById(int id);
        Task<Category> EditCategory(Category model) ;
        Task<int> DeleteCategory(int id);
    }
}