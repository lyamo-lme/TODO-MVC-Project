using DataBaseIndus.GraphQL.Categories;
using DataBaseIndus.GraphQL.Task;
using GraphQL.Types;

namespace DataBaseIndus.GraphQL
{
    public class RootQuery:ObjectGraphType
    {
        public RootQuery()
        {
            Field<TaskQuery>()
                .Name("TasksQueries")
                .Resolve(_ => new { });

            Field<CategoryQuery>()
                .Name("CategoriesQueries")
                .Resolve(_ => new { });
        }
    }
}
