using DataBaseIndus.Models;

namespace DataBaseIndus.Data
{
    public interface ICategoryRepository
    {
        void AddCategory(Category model);
        List<Category> GetCategories();
        Category GetCategoryTasks(int id);

        void EditCategory(Category model);
        void DeleteCategory(int id);
    }
}