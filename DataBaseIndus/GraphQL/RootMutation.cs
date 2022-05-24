using DataBaseIndus.GraphQL.Categories;
using DataBaseIndus.GraphQL.Task;
using GraphQL.Types;

namespace DataBaseIndus.GraphQL
{
    public class RootMutation : ObjectGraphType
    {
        public RootMutation()
        {
            Field<TaskMutation>()
                    .Name("TaskMutation")
                    .Resolve(_ => new { });

            Field<CategoryMutation>()
                .Name("CategoryMutation")
                .Resolve(_ => new { });

               
            
        }
    }
}
