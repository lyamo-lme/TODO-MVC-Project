using GraphQL.Types;
using ToDoList.Models;

namespace ToDoList.GraphQL.Task.Models
{
    public class CreateTaskType : InputObjectGraphType<CreateTodoModel>
    {
        public CreateTaskType() {
            Name = "CreateTodoType";
            Description = "Type Todo Model For Create Task";
            Field(prop => prop.NameTodo, nullable: false).Description("Todo NameTodo");
            Field(prop => prop.DeadLine, nullable: true).Description("Todo DeadLine");
            Field(prop => prop.TaskCompleted, nullable: false).Description("Todo TodoCompleted");
            Field(prop => prop.CategoryId, nullable: false).Description("Todo CategoryId");
        }
    }
}
