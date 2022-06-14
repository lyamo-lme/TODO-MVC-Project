using ToDoList.GraphQL.Task;
using ToDoList.GraphQL.TaskQL.Models;
using GraphQL.Types;

namespace ToDoList.GraphQL
{
    public class DataSchema:Schema
    {
        public DataSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<RootQuery>();
            Mutation = serviceProvider.GetRequiredService<RootMutation>();
        }
    }
}
