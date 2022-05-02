using Dapper;
using DataBaseIndus.Models;
using System.Data;
using System.Data.SqlClient;

namespace DataBaseIndus.Data
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string ConnectionString;
        public TaskRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        public IDbConnection Connection
        {

            get => new SqlConnection(ConnectionString);

        }
        public void AddTask(AddTask model)
        {

            string query = @"
                 INSERT INTO TASKS (NameTask, DeadLine, CategoryId,TaskCompleted)
                        VALUES (@NameTask,@DeadLine,@CategoryID,@TaskCompleted)";
            try
            {
                using (IDbConnection connection = Connection)
                {
                    connection.Open();
                    connection.Query(query, model);
                    connection.Close();

                }
            }
            catch { }
        }
        public List<Tasks> GetTasks(int? mode=0)
        {
            string ModeQuery = " ";
            if (mode == 1) {
                ModeQuery = "Where TaskCompleted=0";
            }
            if (mode == 2) {
                ModeQuery = "Where TaskCompleted=1";
            }
            string query = $"SELECT * FROM Tasks a LEFT JOIN Categories b ON a.CategoryId = b.IdCategory {ModeQuery} ORDER BY case when DeadLine is null then 1 else 0 end, DeadLine asc ";
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                List<Tasks> tasks = connection.Query<Tasks, Category, Tasks>(query, (a, b) => { a.category = b; return a; }, splitOn: "IdCategory").ToList();
                connection.Close();
                return tasks;
            }
        }
        public Tasks GetTaskId(int? id)
        {
            using (IDbConnection connection = Connection)
            {
                Tasks model;
                string sql = "Select * From Tasks Where Id=@id";
                connection.Open();
                model = connection.Query<Tasks>(sql,new { id }).FirstOrDefault();
                connection.Close();
                return model;
            }
        }
        public int  UpdateTask(EditTask model)
        {
            using (IDbConnection connection = Connection)
            {
                string sql = "Update Tasks SET NameTask=@NameTask, TaskCompleted=@TaskCompleted,DeadLine=@DeadLine, CategoryId=@CategoryId Where Id=@Id";
                connection.Open();
                int i=connection.Execute(sql, model);
                connection.Close();
                return i;
            }

        }
        public void DeleteTask(int? id) {
            using (IDbConnection connection = Connection) {
                string sql = "Delete From Tasks Where Id=@Id";
                connection.Open();
                connection.Query(sql, new { id });
                connection.Close();
            }
        }
    }
}
