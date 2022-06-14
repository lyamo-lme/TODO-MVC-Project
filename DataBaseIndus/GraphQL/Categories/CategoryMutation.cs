using AutoMapper;
using ToDoList.Data;
using ToDoList.GraphQL.Categories.Models;
using ToDoList.Models.DbModel;
using GraphQL;
using GraphQL.Types;
using ToDoList.Models;

namespace ToDoList.GraphQL.Categories
{
    public class CategoryMutation:ObjectGraphType
    {
        private ICategoryRepository categoryRepository { get; set; }
        public CategoryMutation(IServiceProvider serviceProvider, IMapper mapper) {
            CurrentRepository.ChangeRepository(serviceProvider, CurrentRepository.currentSource);
            categoryRepository = CurrentRepository.categoryRepository;

            Field<CategoryType, Category>()
                  .Name("Create")
                  .Argument<NonNullGraphType<CreateCategoryType>, CreateTodoModel>("NewCategory", "New category arguments")
                  .Resolve(context =>
                  {

                      var input = context.GetArgument<CreateCategory>("NewCategory");
                      var task = mapper.Map<Category>(input);
                      categoryRepository.CreateCategory(task);
                      return mapper.Map<Category>(task);
                  });

            Field<CategoryType, Category>()
                .Name("Update")
                .Argument<NonNullGraphType<EditCategoryType>, Category>("EditCategory", "Update category arguments")
                .Resolve(context => {
                    var input = context.GetArgument<Category>("EditCategory");
                    var task = mapper.Map<Category>(input);
                   
                    return  categoryRepository.EditCategory(task);
                });

            Field<CategoryType, Category>()
                .Name("Delete")
                .Argument<IntGraphType, int>("DeleteId", "id for delete category")
                .Resolve(context => {
                    int Id = context.GetArgument<int>("DeleteId");
                    Category model = categoryRepository.GetCategoryById(Id);
                    categoryRepository.DeleteCategory(Id);
                    return model;
                });
        }
    }
}
