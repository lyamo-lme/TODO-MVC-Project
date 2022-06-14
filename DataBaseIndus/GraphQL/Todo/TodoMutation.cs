using AutoMapper;
using ToDoList.Data;
using ToDoList.Enums;
using ToDoList.GraphQL.Task.Models;
using ToDoList.GraphQL.TaskQL.Models;
using ToDoList.Models.DbModel;
using GraphQL;
using GraphQL.Types;
using ToDoList.Models;

namespace ToDoList.GraphQL.Task
{
    public class TodoMutation : ObjectGraphType
    {
        private ITodoRepository taskRepository { get; set; }
        public TodoMutation(IServiceProvider service, IMapper mapper)
        {
            CurrentRepository.ChangeRepository(service, CurrentRepository.currentSource);

            taskRepository = CurrentRepository.taskRepository;
            Field<TaskType, TodoModel>()
                .Name("Create")
                .Argument<NonNullGraphType<CreateTaskType>, CreateTodoModel>("Todo", "New task arguments")
                .Resolve(context =>
                {
                    var input = context.GetArgument<CreateTodoModel>("Todo");
                    var task = mapper.Map<TodoModel>(input);
                    task.TaskCompleted = false;
                    return taskRepository.CreateTask(task);
                });

            Field<TaskType, TodoModel>()
                .Name("Update")
                .Argument<NonNullGraphType<EditTaskType>, EditTodoModel>("EditTodo", "Update todo arguments")
                .Resolve(context => {
                    var input = context.GetArgument<EditTodoModel>("EditTodo");
                    var task = mapper.Map<TodoModel>(input);
                    return mapper.Map<TodoModel>(taskRepository.UpdateTask(task));
                    });

            Field<TaskType, TodoModel>()
                .Name("Delete")
                .Argument<IntGraphType, int>("DeleteId", "id for delete todo")
                .Resolve(context=>{
                    int Id= context.GetArgument<int>("DeleteId");
                    TodoModel model = taskRepository.GetTaskId(Id);
                    int result = taskRepository.DeleteTask(Id);
                    return model;
                });


            Field<StringGraphType, string>()
                .Name("ChangeRepositoryType")
                .Argument<StringGraphType, string>("TypeSource", "type of source")
                .Resolve(context =>
                {
                    typeSource typeSource=CurrentRepository.currentSource;
                    string typeSourceString = context.GetArgument<string>("TypeSource");
                    if ( typeSourceString== "XML") {
                        typeSource = typeSource.XML;
                        typeSourceString = "XML";
                    }
                    if (typeSourceString == "Db") {
                        typeSource = typeSource.Db;
                        typeSourceString = "Db";
                    }
                    CurrentRepository.ChangeRepository(service, typeSource);
                    return typeSourceString;
                    
                });
            
        }
    }
}
