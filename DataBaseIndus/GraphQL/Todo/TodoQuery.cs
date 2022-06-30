using ToDoList.Data;
using ToDoList.GraphQL.TaskQL.Models;
using ToDoList.Models.DbModel;
using GraphQL;
using GraphQL.Types;

namespace ToDoList.GraphQL.Task
{
    public class TodoQuery : ObjectGraphType
    {
        
        public TodoQuery(IServiceProvider serviceProvider)
        {
            CurrentRepository.ChangeRepository(serviceProvider, CurrentRepository.currentSource);
            Field<NonNullGraphType<ListGraphType<TaskType>>, List<TodoModel>>()
                          .Name("GetAllTodos")
                          .Resolve(context =>
                          {
                              return CurrentRepository.taskRepository.GetTasks();
                          });

            Field<TaskType, TodoModel>()
                .Name("GetTodoById")
                .Argument<IntGraphType, int>("TaskId", "Get Todo By Id")
                .Resolve(context =>
                {
                    return CurrentRepository.taskRepository.GetTaskId(context.GetArgument<int>("TodoId"));
                }
                );
        }

    }
}
