using GraphQL.Types;
using ToDoList.Models;

namespace DataBaseIndus.GraphQL.Task.Models
{
    public class EditTaskType : InputObjectGraphType<EditTask>
    {
        public EditTaskType()
        {
            Name = "EditTaskType";
            Field(prop => prop.NameTask, nullable: false).Description("Task NameTask");
            Field(prop => prop.Id, nullable: false).Description("Task Id");
            Field(prop => prop.DeadLine, nullable: true).Description("Task DeadLine");
            Field(prop => prop.TaskCompleted, nullable: false).Description("Task TaskCompleted");
            Field(prop => prop.CategoryId, nullable: false).Description("Task CategoryId");
        }
    }
}
