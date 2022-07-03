using ToDoList.GraphQL.Categories;
using ToDoList.GraphQL.Task;
using GraphQL.Types;
using ToDoList.GraphQL.Repository;

namespace ToDoList.GraphQL
{
    public class RootMutation : ObjectGraphType
    {
        public RootMutation()
        {
            Field<TodoMutation>()
                    .Name("TasksMutation")
                    .Resolve(_ => new { });

            Field<CategoryMutation>()
                .Name("CategoryMutation")
                .Resolve(_ => new { });

            Field<RepositoryMutation>()
                .Name("RepositoryMutation")
                .Resolve(_ => new { });

            
        }
    }
}
