using ToDoList.Models.DbModel;
using GraphQL.Types;

namespace ToDoList.GraphQL.Categories.Models
{
    public class EditCategoryType:InputObjectGraphType<Category>
    {
        public EditCategoryType() {
            Name = "EditCategoryType";
            Field(prop => prop.IdCategory).Description("Edit Category id");
            Field(prop => prop.NameCategory).Description("Edit Category Name");
        }
    }
}
