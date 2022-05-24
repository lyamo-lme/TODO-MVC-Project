using DataBaseIndus.Models.DbModel;

namespace ToDoList.Data
{
    public interface ITaskRepository
    {
        Tasks? CreateTask(Tasks tasks);
        Tasks GetTaskId(int? id);
        Tasks UpdateTask(Tasks model);
        int DeleteTask(int? id);
        
        List<Tasks> GetTasks(int? mode=0);
    }
}
