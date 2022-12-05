using ToDoList.Models.DbModel;

namespace ToDoList.Data
{
    public interface ITodoRepository
    {
        TodoModel? CreateTask(TodoModel tasks);
        TodoModel GetTaskId(int? id);
        TodoModel UpdateTask(TodoModel model);
        int DeleteTask(int? id);
        
        Task<List<TodoModel>> GetTasks(int? mode=0);
    }
}
