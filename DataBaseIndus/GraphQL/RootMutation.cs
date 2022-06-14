using ToDoList.GraphQL.Categories;
using ToDoList.GraphQL.Task;
using GraphQL.Types;

namespace ToDoList.GraphQL
{
    public class RootMutation : ObjectGraphType
    {
        public RootMutation()
        {
            Field<TodoMutation>()
                    .Name("TaskMutation")
                    .Resolve(_ => new { });

            Field<CategoryMutation>()
                .Name("CategoryMutation")
                .Resolve(_ => new { });

            
        }
    }
}
