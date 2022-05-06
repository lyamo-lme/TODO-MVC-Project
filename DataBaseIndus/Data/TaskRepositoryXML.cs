using Dapper;
using DataBaseIndus.Models;
using System.Data;
using System.Data.SqlClient;

namespace DataBaseIndus.Data
{
    public class TaskRepositoryXML : ITaskRepository
    {
        public TaskRepositoryXML()
        {
        }

        public void AddTask(AddTask model)
        {

        }
        public List<Tasks> GetTasks(int? mode = 0)
        {
            List<Tasks> model = new List<Tasks>{
            new Tasks { Id=0, NameTask="loh", TaskCompleted=true,CategoryId=2},
            new Tasks { Id=0, NameTask="loh2", TaskCompleted=true,CategoryId=2}
            };
            return model;
        }
        public Tasks GetTaskId(int? id)
        {
            return new Tasks();
        }
        public int UpdateTask(EditTask model)
        {
            return 0;
        }
        public void DeleteTask(int? id)
        {

        }
    }
}
