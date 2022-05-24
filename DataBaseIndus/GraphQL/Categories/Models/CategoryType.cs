using DataBaseIndus.Data;
using DataBaseIndus.GraphQL.TaskQL.Models;
using DataBaseIndus.Models.DbModel;
using GraphQL.Types;

namespace DataBaseIndus.GraphQL.Categories.Models
{
    public class CategoryType: ObjectGraphType<Category>
    {

        public CategoryType() {
            Name = "CategoryType";
            Description = "Category Model Type";
            Field(prop => prop.NameCategory).Description("Category Name");
            Field(prop => prop.IdCategory).Description("Category IdCategory");

            Field<NonNullGraphType<ListGraphType<TaskType>>, List<Tasks>>()
               .Name("tasks")
               .Resolve(context =>
               { 
                   int categoryId = context.Source.IdCategory;
                   return  CurrentRepository.categoryRepository.GetCategoryTasks(categoryId).tasks;
               });

        }
    }
}
