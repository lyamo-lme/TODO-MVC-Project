using AutoMapper;
using DataBaseIndus.Models.DbModel;
using ToDoList.Models;

namespace ToDoList.Mapper
{
    public class Mapper:Profile
    {
        public Mapper() {
            CreateMap<Tasks, DeleteTaskViewModel>().ReverseMap();
            CreateMap<Tasks, EditTask>().ReverseMap();
            CreateMap<Tasks, CreateTask>().ReverseMap();
            CreateMap<Category, CreateCategory>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();
          /*  CreateMap<Category,CategoryViewModel>();
            CreateMap<List<Category>, List<CategoryViewModel>>();*/

        }
    }
}
