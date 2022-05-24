using DataBaseIndus.Data;
using DataBaseIndus.Models.DbModel;
using GraphQL.Types;

namespace DataBaseIndus.GraphQL.TaskQL.Models
{
    public class TaskType : ObjectGraphType<Tasks>
    {
        public TaskType()
        {
            Name="Tasks";
            Description = "Task Type";
            Field(prop => prop.Id, nullable: false).Description("Task Id");
            Field(prop => prop.NameTask, nullable: false).Description("Task NameTask");
            Field(prop => prop.TaskCompleted, nullable: false).Description("Task TaskCompleted");
            Field(prop => prop.DeadLine, nullable: true).Description("Task DeadLine");
            Field(prop => prop.CategoryId, nullable: false).Description("Task CategoryId");
            Field(prop => prop.NameCategory, nullable: true).Description("Task NameCategory");

        }

    }
}
