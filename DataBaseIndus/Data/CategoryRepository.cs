using Dapper;
using ToDoList.Models;
using System.Data;
using System.Data.SqlClient;

namespace ToDoList.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        public CategoryRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = this.configuration.GetConnectionString("DefaultConnection");
        }
        public IDbConnection Connection
        {

            get => new SqlConnection(connectionString);

        }
        public void AddCategory(AddCategory model)
        {
            using (Connection)
            {
                string Query = @"Insert INTO Categories (NameCategory)
                      Values(@NameCategory)
                      ";
                Connection.Open();
                Connection.Query(Query, model);
                Connection.Close();
            }
        }
        public Category GetCategoryTasks(int id)
        {
            var sql = @"select b.IdCategory , b.NameCategory from Categories b where IdCategory = @id ";
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                Category category = connection.Query<Category>(sql, new { id } ).FirstOrDefault();
                sql = $"Select * from Tasks Where CategoryId={id} ORDER BY case when DeadLine is null then 1 else 0 end, DeadLine asc";
                category.tasks = connection.Query<Tasks>(sql,category.tasks).ToList();
                connection.Close();
                return category;
            }

        }
        public Category GetCategoryById(int id) {
            var sql = @"select b.IdCategory , b.NameCategory from Categories b where IdCategory = @id ";
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                Category category = connection.Query<Category>(sql, new { id }).FirstOrDefault();
                connection.Close();
                return category;
            }

        }
        public void DeleteCategory(int id) {
            using (IDbConnection connection = Connection)
            {
                string sql = $"Delete From Categories Where IdCategory={id}";
                connection.Open();
                connection.Query(sql);
                connection.Close();
             }
        }
        public void EditCategory(Category model) {
            using (IDbConnection connection = Connection)
            {
                string sql = "Update Categories SET NameCategory=@NameCategory Where IdCategory=@IdCategory";
                connection.Open();
                connection.Query(sql, model);
                connection.Close();
            }
        }
        public List<Category> GetCategories()
        {
            string Query = "Select * From Categories";
            using (Connection)
            {
                Connection.Open();
                List<Category> categories = Connection.Query<Category>(Query).ToList();
                Connection.Close();
                return categories;
            }
        }
    }
}
