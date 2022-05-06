using DataBaseIndus.Models;

namespace DataBaseIndus.Data
{
    public class CategoryRepositoryXML : ICategoryRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string ConnectionString;
        public CategoryRepositoryXML(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public void AddCategory(Category model)
        {

        }
        public Category GetCategoryTasks(int id)
        {
            return new Category();

        }
        public void DeleteCategory(int id)
        {

        }
        public void EditCategory(Category model)
        {

        }
        public List<Category> GetCategories()
        {

            List<Category> categories =new  List<Category>{
            new Category { IdCategory=2, NameCategory="dasdas"  }
            };
                return categories;

        }
    }
}
