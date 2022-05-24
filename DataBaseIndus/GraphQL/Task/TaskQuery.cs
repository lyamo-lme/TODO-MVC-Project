using DataBaseIndus.Data;
using DataBaseIndus.GraphQL.TaskQL.Models;
using DataBaseIndus.Models.DbModel;
using GraphQL;
using GraphQL.Types;
using ToDoList.Data;

namespace DataBaseIndus.GraphQL.Task
{
    public class TaskQuery : ObjectGraphType
    {
        private ITaskRepository taskRepository { get; set; }
        public TaskQuery(IServiceProvider serviceProvider)
        {
            CurrentRepository.Initialization(serviceProvider, CurrentRepository.currentSource);
            taskRepository = CurrentRepository.taskRepository;
            Field<NonNullGraphType<ListGraphType<TaskType>>, List<Tasks>>()
                          .Name("GetAllTasks")
                          .Resolve(context =>
                          {
                              return taskRepository.GetTasks();
                          });

            Field<TaskType, Tasks>()
                .Name("GetTaskById")
                .Argument<IntGraphType, int>("TaskId", "Get Task By Id")
                .Resolve(context =>
                {
                    return taskRepository.GetTaskId(context.GetArgument<int>("TaskId"));
                }
                );
        }

    }
}
