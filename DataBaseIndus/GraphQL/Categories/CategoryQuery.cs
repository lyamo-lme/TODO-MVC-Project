using DataBaseIndus.Data;
using DataBaseIndus.GraphQL.Categories.Models;
using DataBaseIndus.Models.DbModel;
using GraphQL;
using GraphQL.Types;
using ToDoList.Data;

namespace DataBaseIndus.GraphQL.Categories
{
    public class CategoryQuery : ObjectGraphType
    {
        private ICategoryRepository categoryRepository { get; set; }
        public CategoryQuery(IServiceProvider serviceProvider)
        {

            CurrentRepository.Initialization(serviceProvider, CurrentRepository.currentSource);
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
