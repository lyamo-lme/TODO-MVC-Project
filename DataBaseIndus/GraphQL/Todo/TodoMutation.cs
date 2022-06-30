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
        public TodoMutation(IServiceProvider service, IMapper mapper)
        {
            Field<TaskType, TodoModel>()
                .Name("Create")
                .Argument<NonNullGraphType<CreateTaskType>, CreateTodoModel>("Todo", "New todo arguments")
                .Resolve(context =>
                {
                    var input = context.GetArgument<CreateTodoModel>("Todo");
                    var task = mapper.Map<TodoModel>(input);
                    task.TaskCompleted = false;
                    return CurrentRepository.taskRepository.CreateTask(task);
                });

            Field<TaskType, TodoModel>()
                .Name("Update")
                .Argument<NonNullGraphType<EditTaskType>, EditTodoModel>("EditTodo", "Update todo arguments")
                .Resolve(context => {
                    var input = context.GetArgument<EditTodoModel>("EditTodo");
                    var task = mapper.Map<TodoModel>(input);
                    return mapper.Map<TodoModel>(CurrentRepository.taskRepository.UpdateTask(task));
                    });

            Field<TaskType, TodoModel>()
                .Name("Delete")
                .Argument<IntGraphType, int>("DeleteId", "id for delete todo")
                .Resolve(context=>{
                    int Id= context.GetArgument<int>("DeleteId");
                    TodoModel model = CurrentRepository.taskRepository.GetTaskId(Id);
                    int result = CurrentRepository.taskRepository.DeleteTask(Id);
                    return model;
                });


            
        }
    }
}
