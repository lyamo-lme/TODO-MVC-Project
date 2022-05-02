using DataBaseIndus.Models;
namespace DataBaseIndus.Data
{
    public interface ITaskRepository
    {
        void AddTask(AddTask tasks);
        Tasks GetTaskId(int? id);
        int UpdateTask(EditTask model);
        void DeleteTask(int? id);
        
        List<Tasks> GetTasks(int? mode=0);
    }
}
