using AutoMapper;
using DataBaseIndus.Data;
using DataBaseIndus.Enums;
using DataBaseIndus.GraphQL.Task.Models;
using DataBaseIndus.GraphQL.TaskQL.Models;
using DataBaseIndus.Models.DbModel;
using GraphQL;
using GraphQL.Types;
using ToDoList.Data;
using ToDoList.Models;

namespace DataBaseIndus.GraphQL.Task
{
    public class TaskMutation : ObjectGraphType
    {
        private ITaskRepository taskRepository { get; set; }
        public TaskMutation(IServiceProvider service, IMapper mapper)
        {
            CurrentRepository.Initialization(service, CurrentRepository.currentSource);

            taskRepository = CurrentRepository.taskRepository;
            Field<TaskType, Tasks>()
                .Name("Create")
                .Argument<NonNullGraphType<CreateTaskType>, CreateTask>("NewTask", "New task arguments")
                .Resolve(context =>
                {
                    var input = context.GetArgument<CreateTask>("NewTask");
                    var task = mapper.Map<Tasks>(input);
                    task.TaskCompleted = false;
                    return taskRepository.CreateTask(task);
                });

            Field<TaskType, Tasks>()
                .Name("Update")
                .Argument<NonNullGraphType<EditTaskType>, EditTask>("EditTask", "Update task arguments")
                .Resolve(context => {
                    var input = context.GetArgument<EditTask>("EditTask");
                    var task = mapper.Map<Tasks>(input);
                    return mapper.Map<Tasks>(taskRepository.UpdateTask(task));
                    });

            Field<TaskType, Tasks>()
                .Name("Delete")
                .Argument<IntGraphType, int>("DeleteId","id for delete task")
                .Resolve(context=>{
                    int Id= context.GetArgument<int>("DeleteId");
                    Tasks model = taskRepository.GetTaskId(Id);
                    int result = taskRepository.DeleteTask(Id);
                    return model;
                });


            Field<StringGraphType, string>()
                .Name("ChangeRepositoryType")
                .Argument<StringGraphType, string>("TypeSource", "type of source")
                .Resolve(context =>
                {
                    typeSource typeSource=typeSource.Db;
                    string typeSourceString = context.GetArgument<string>("TypeSource");
                    if ( typeSourceString== "XML") {
                        typeSource = typeSource.XML;
                        typeSourceString = "XML";
                    }
                    if (typeSourceString == "Db") {
                        typeSource = typeSource.Db;
                        typeSourceString = "Db";
                    }
                    CurrentRepository.Initialization(service, typeSource);
                    return typeSourceString;
                    []
                });
            
        }
    }
}
