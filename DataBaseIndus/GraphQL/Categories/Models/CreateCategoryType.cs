using GraphQL.Types;
using ToDoList.Models;

namespace ToDoList.GraphQL.Categories.Models
{
    public class CreateCategoryType:InputObjectGraphType<CreateCategory>
    {
        public CreateCategoryType() {
            Name = "CreateCategoryType"; 

            Field(prop => prop.NameCategory).Description("Category Name");
        }
    }
}
