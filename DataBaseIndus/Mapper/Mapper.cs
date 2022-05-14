using AutoMapper;
using ToDoList.Models;

namespace ToDoList.Mapper
{
    public class Mapper:Profile
    {
        public Mapper() {
            CreateMap<Tasks, DeleteTaskViewModel>();
            CreateMap<Tasks, EditTask>();
          /*  CreateMap<Category,CategoryViewModel>();
            CreateMap<List<Category>, List<CategoryViewModel>>();*/

      
           
  
        }
    }
}
