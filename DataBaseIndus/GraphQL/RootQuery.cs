using ToDoList.GraphQL.Categories;
using ToDoList.GraphQL.Task;
using GraphQL.Types;

namespace ToDoList.GraphQL
{
    public class RootQuery:ObjectGraphType
    {
        public RootQuery()
        {
            Field<TodoQuery>()
                .Name("TasksQueries")
                .Resolve(_ => new { });

            Field<CategoryQuery>()
                .Name("CategoriesQueries")
                .Resolve(_ => new { });
        }
    }
}
