using GraphQL.Types;
using ToDoList.Models;

namespace DataBaseIndus.GraphQL.Task.Models
{
    public class CreateTaskType : InputObjectGraphType<CreateTask>
    {
        public CreateTaskType() {
            Name = "CreateTaskType";
            Description = "Type Task Model For Create Task";
            Field(prop => prop.NameTask, nullable: false).Description("Task NameTask");
            Field(prop => prop.DeadLine, nullable: true).Description("Task DeadLine");
            Field(prop => prop.TaskCompleted, nullable: false).Description("Task TaskCompleted");
            Field(prop => prop.CategoryId, nullable: false).Description("Task CategoryId");
        }
    }
}
