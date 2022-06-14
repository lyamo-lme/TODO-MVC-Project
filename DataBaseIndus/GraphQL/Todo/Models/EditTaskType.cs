using GraphQL.Types;
using ToDoList.Models;

namespace ToDoList.GraphQL.Task.Models
{
    public class EditTaskType : InputObjectGraphType<EditTodoModel>
    {
        public EditTaskType()
        {
            Name = "EditTodoType";
            Field(prop => prop.NameTodo, nullable: false).Description("Todo NameTodo");
            Field(prop => prop.Id, nullable: false).Description("Todo Id");
            Field(prop => prop.DeadLine, nullable: true).Description("Todo DeadLine");
            Field(prop => prop.TaskCompleted, nullable: false).Description("Todo TodoCompleted");
            Field(prop => prop.CategoryId, nullable: true).Description("Todo CategoryId");
        }
    }
}
