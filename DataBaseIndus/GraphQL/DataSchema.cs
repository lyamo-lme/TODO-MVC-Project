using DataBaseIndus.GraphQL.Task;
using DataBaseIndus.GraphQL.TaskQL.Models;
using GraphQL.Types;

namespace DataBaseIndus.GraphQL
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
