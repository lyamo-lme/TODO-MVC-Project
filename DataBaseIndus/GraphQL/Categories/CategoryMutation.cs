using AutoMapper;
using ToDoList.Data;
using ToDoList.GraphQL.Categories.Models;
using ToDoList.Models.DbModel;
using GraphQL;
using GraphQL.Types;
using ToDoList.Models;

namespace ToDoList.GraphQL.Categories
{
    public class CategoryMutation : ObjectGraphType
    {
        public CategoryMutation(IServiceProvider serviceProvider, IMapper mapper)
        {
            
            Field<CategoryType, Category>()
                  .Name("Create")
                  .Argument<NonNullGraphType<CreateCategoryType>, CreateTodoModel>("NewCategory", "New category arguments")
                  .ResolveAsync(async context =>
                  {
                      var input = context.GetArgument<CreateCategory>("NewCategory");
                      var task = mapper.Map<Category>(input);
                      task = await CurrentRepository.categoryRepository.CreateCategory(task);
                      return task;
                  });

            Field<CategoryType, Category>()
                .Name("Update")
                .Argument<NonNullGraphType<EditCategoryType>, Category>("EditCategory", "Update category arguments")
                .ResolveAsync(async context =>
                {
                    var input = context.GetArgument<Category>("EditCategory");
                    var task = mapper.Map<Category>(input);
                    return await CurrentRepository.categoryRepository.EditCategory(task);
                });

            Field<CategoryType, Category>()
                .Name("Delete")
                .Argument<IntGraphType, int>("DeleteId", "id for delete category")
                .ResolveAsync(async context =>
                {
                    int Id = context.GetArgument<int>("DeleteId");
                    Category model = await CurrentRepository.categoryRepository.GetCategoryById(Id);
                    int result = await CurrentRepository.categoryRepository.DeleteCategory(Id);
                    return model;
                });
        }
    }
}
