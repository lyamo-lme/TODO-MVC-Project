using ToDoList.Data;
using ToDoList.GraphQL.TaskQL.Models;
using ToDoList.Models.DbModel;
using GraphQL.Types;

namespace ToDoList.GraphQL.Categories.Models
{
    public class CategoryType: ObjectGraphType<Category>
    {

        public CategoryType() {
            Name = "CategoryType";
            Description = "Category Model Type";
            Field(prop => prop.NameCategory).Description("Category Name");
            Field(prop => prop.IdCategory).Description("Category IdCategory");

            Field<NonNullGraphType<ListGraphType<TaskType>>, List<TodoModel>>()
               .Name("tasks")
               .Resolve(context =>
               { 
                   int categoryId = context.Source.IdCategory;
                   return  CurrentRepository.categoryRepository.GetCategoryTasks(categoryId).tasks;
               });

        }
    }
}
