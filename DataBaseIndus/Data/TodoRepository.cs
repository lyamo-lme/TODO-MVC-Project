using Dapper;
using System.Data;
using System.Data.SqlClient;
using ToDoList.Models.DbModel;

namespace ToDoList.Data
{
    public class TodoRepository : ITodoRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string ConnectionString;
        public TodoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration["ConnectionStrings"];
        }
        public IDbConnection Connection
        {

            get => new SqlConnection(ConnectionString);

        }
        public TodoModel? CreateTask(TodoModel model)
        {

            string query = @$"
                 INSERT INTO TASKS ({nameof(model.NameTodo)}, {nameof(model.DeadLine)}, {nameof(model.CategoryId)},{nameof(model.TaskCompleted)})
                        VALUES (@{nameof(model.NameTodo)},@{nameof(model.DeadLine)},@{nameof(model.CategoryId)},@{nameof(model.TaskCompleted)})
                       SELECT @@IDENTITY";

            using (IDbConnection connection = Connection)
            {
                connection.Open();
                int id = connection.QueryFirst<int>(query, model); 
                connection.Close();
                return GetTaskId(id);
            }
        }
        public async Task<List<TodoModel>> GetTasks(int? mode = 0)
        {
            string ModeQuery = " ";
            if (mode == 1)
            {
                ModeQuery = "Where TaskCompleted=0";
            }
            if (mode == 2)
            {
                ModeQuery = "Where TaskCompleted=1";
            }
            string query = $"SELECT * FROM Tasks a LEFT JOIN Categories b ON a.CategoryId = b.IdCategory {ModeQuery} ORDER BY case when DeadLine is null then 1 else 0 end, DeadLine asc ";
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                var tasks = await connection.QueryAsync<TodoModel>(query);
                connection.Close();
                return tasks.ToList();
            }
        }
        public TodoModel GetTaskId(int? id)
        {
            using (IDbConnection connection = Connection)
            {

                string sql = "Select * From Tasks Where Id=@id";
                connection.Open();
                TodoModel model = connection.QueryFirstOrDefault<TodoModel>(sql, new { id });
                id = model.CategoryId;
                model.NameCategory = connection.QueryFirstOrDefault<string>("Select NameCategory from Categories where IdCategory=@id", new { id });
                connection.Close();
                return model;
            }
        }
        public TodoModel UpdateTask(TodoModel model)
        {
            using (IDbConnection connection = Connection)
            {
                string sql = "Update Tasks SET NameTodo=@NameTodo, TaskCompleted=@TaskCompleted,DeadLine=@DeadLine, CategoryId=@CategoryId Where Id=@Id";
                connection.Open();
                int i = connection.Execute(sql, model);
                connection.Close();
                return GetTaskId(model.Id);
            }

        }
        public int DeleteTask(int? id)
        {
            using (IDbConnection connection = Connection)
            {
                string sql = "Delete From Tasks Where Id=@Id";
                connection.Open();
                int result = connection.Execute(sql, new { id });
                connection.Close();
                return result;
            }
        }
    }
}
