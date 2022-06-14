using ToDoList.Data;
using ToDoList.GraphQL.TaskQL.Models;
using ToDoList.Models.DbModel;
using GraphQL;
using GraphQL.Types;

namespace ToDoList.GraphQL.Task
{
    public class TodoQuery : ObjectGraphType
    {
        private ITodoRepository taskRepository { get; set; }
        public TodoQuery(IServiceProvider serviceProvider)
        {
            CurrentRepository.ChangeRepository(serviceProvider, CurrentRepository.currentSource);
            taskRepository = CurrentRepository.taskRepository;
            Field<NonNullGraphType<ListGraphType<TaskType>>, List<TodoModel>>()
                          .Name("GetAllTodos")
                          .Resolve(context =>
                          {
                              return taskRepository.GetTasks();
                          });

            Field<TaskType, TodoModel>()
                .Name("GetTodoById")
                .Argument<IntGraphType, int>("TaskId", "Get Todo By Id")
                .Resolve(context =>
                {
                    return taskRepository.GetTaskId(context.GetArgument<int>("TodoId"));
                }
                );
        }

    }
}
