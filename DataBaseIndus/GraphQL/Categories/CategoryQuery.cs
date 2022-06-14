using ToDoList.Data;
using ToDoList.GraphQL.Categories.Models;
using ToDoList.Models.DbModel;
using GraphQL;
using GraphQL.Types;

namespace ToDoList.GraphQL.Categories
{
    public class CategoryQuery : ObjectGraphType
    {
        private ICategoryRepository categoryRepository { get; set; }
        public CategoryQuery(IServiceProvider serviceProvider)
        {

            CurrentRepository.ChangeRepository(serviceProvider, CurrentRepository.currentSource);
            categoryRepository = CurrentRepository.categoryRepository;

            Field<NonNullGraphType<ListGraphType<CategoryType>>, List<Category>>()
                 .Name("GetAllCategories")
                 .Resolve(context =>
                 {
                     return categoryRepository.GetCategories();
                 }
                 );

            Field<CategoryType, Category>()
                .Name("GetCategoryById")
                .Argument<IntGraphType, int>("CategoryId", "id for get category")
                .Resolve(context=>
                {
                    return categoryRepository.GetCategoryTasks(context.GetArgument<int>("CategoryId"));
                }
                );

        }
    }
}
