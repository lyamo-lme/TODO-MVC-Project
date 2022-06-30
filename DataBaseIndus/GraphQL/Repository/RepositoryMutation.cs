using GraphQL.Types;
using GraphQL;
using ToDoList.Data;
using ToDoList.Enums;

namespace ToDoList.GraphQL.Repository
{

    public class RepositoryMutation : ObjectGraphType
    {
        public RepositoryMutation(IServiceProvider service)
        {
            Field<StringGraphType, string>()
                    .Name("ChangeRepositoryType")
                    .Argument<StringGraphType, string>("TypeSource", "type of source")
                    .Resolve(context =>
                    {
                        typeSource typeSource = CurrentRepository.currentSource;
                        string typeSourceString = context.GetArgument<string>("TypeSource");
                        switch (typeSourceString)
                        {
                            case "XML":
                                {
                                    typeSource = typeSource.XML;
                                    break;
                                }
                            case "DB":
                                {
                                    typeSource = typeSource.Db;
                                    break;
                                }
                        }
                        CurrentRepository.ChangeRepository(service, typeSource);
                        return typeSourceString;
                    });
        }
    }
}
