using Dapper;
using ToDoList.Models;
using System.Data;
using System.Data.SqlClient;
using ToDoList.Models.DbModel;

namespace ToDoList.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        public CategoryRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = configuration["ConnectionStrings"];
        }
        public IDbConnection Connection
        {

            get => new SqlConnection(connectionString);

        }
        public async Task<Category> CreateCategory(Category model)
        {
            using (Connection)
            {
                string query = @"Insert INTO Categories (NameCategory) Values(@NameCategory) SELECT @@IDENTITY";
                Connection.Open();

                int Id = await Connection.QuerySingleAsync<int>(query, model);
                Connection.Close();
                return await GetCategoryById(Id);
            }
        }
        public async Task<Category> GetCategoryTasks(int id)
        {
            var sql = $"Select * from Tasks Where CategoryId={id} ORDER BY case when DeadLine is null then 1 else 0 end, DeadLine asc";

            using (Connection)
            {
                Connection.Open();
                Category category = await GetCategoryById(id);
                IEnumerable<TodoModel> Tasks = await Connection.QueryAsync<TodoModel>(sql, category.tasks);
                category.tasks = Tasks.ToList();
                Connection.Close();
                return category;
            }
        }
        public async Task<Category> GetCategoryById(int id)
        {
            var sql = @"select b.IdCategory , b.NameCategory from Categories b where IdCategory = @id ";
            using (Connection)
            {
                Connection.Open();
                Category category = await Connection.QueryFirstAsync<Category>(sql, new { id });
                Connection.Close();
                return category;
            }

        }
        public async Task<int> DeleteCategory(int id)
        {
            using (Connection)
            {
                string sql = $"Delete From Categories Where IdCategory={id}";
                Connection.Open();
                int result = await Connection.ExecuteAsync(sql);
                Connection.Close();
                return result;
            }
        }
        public async Task<Category> EditCategory(Category model)
        {
            using (Connection)
            {
                string sql = "Update Categories SET NameCategory=@NameCategory Where IdCategory=@IdCategory";
                Connection.Open();
                await Connection.QueryAsync(sql, model);
                Connection.Close();
                return await GetCategoryTasks(model.IdCategory);
            }
        }
        public async Task<List<Category>> GetCategories()
        {
            string query = "Select * From Categories";
            using (Connection)
            {
                Connection.Open();
                var categories = await Connection.QueryAsync<Category>(query);
                Connection.Close();
                return categories.ToList();
            }
        }
    }
}
