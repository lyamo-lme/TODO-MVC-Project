using AutoMapper;
using ToDoList.Models.DbModel;
using ToDoList.Models;

namespace ToDoList.Mapper
{
    public class Mapper:Profile
    {
        public Mapper() {
            CreateMap<TodoModel, DeleteTodoViewModel>().ReverseMap();
            CreateMap<TodoModel, EditTodoModel>().ReverseMap();
            CreateMap<TodoModel, CreateTodoModel>().ReverseMap();
            CreateMap<Category, CreateCategory>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();
        }
    }
}
