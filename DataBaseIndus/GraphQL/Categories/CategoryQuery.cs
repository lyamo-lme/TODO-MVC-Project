using ToDoList.Data;
using ToDoList.GraphQL.Categories.Models;
using ToDoList.Models.DbModel;
using GraphQL;
using GraphQL.Types;

namespace ToDoList.GraphQL.Categories
{
    public class CategoryQuery : ObjectGraphType
    {
        public CategoryQuery(IServiceProvider serviceProvider)
        {

            Field<NonNullGraphType<ListGraphType<CategoryType>>, List<Category>>()
                 .Name("GetAllCategories")
                 .ResolveAsync(async context =>
                 {
                     return  await CurrentRepository.categoryRepository.GetCategories();
                 }
                 );

            Field<CategoryType, Category>()
                .Name("GetCategoryById")
                .Argument<IntGraphType, int>("CategoryId", "id for get category")
                .ResolveAsync(async context=>
                {
                    return await CurrentRepository.categoryRepository.GetCategoryTasks(context.GetArgument<int>("CategoryId"));
                }
                );

        }
    }
}
