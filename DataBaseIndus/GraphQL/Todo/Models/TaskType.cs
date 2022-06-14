using ToDoList.Data;
using ToDoList.Models.DbModel;
using GraphQL.Types;

namespace ToDoList.GraphQL.TaskQL.Models
{
    public class TaskType : ObjectGraphType<TodoModel>
    {
        public TaskType()
        {
            Name= "Todo";
            Description = "Todo Type";
            Field(prop => prop.Id, nullable: false).Description("Todo Id");
            Field(prop => prop.NameTodo, nullable: false).Description("Todo NameTodo");
            Field(prop => prop.TaskCompleted, nullable: false).Description("Todo TodoCompleted");
            Field(prop => prop.DeadLine, nullable: true).Description("Todo DeadLine");
            Field(prop => prop.CategoryId, nullable: false).Description("Todo CategoryId");
            Field(prop => prop.NameCategory, nullable: true).Description("Todo NameCategory");

        }

    }
}
