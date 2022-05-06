using AutoMapper;
using DataBaseIndus.Models;

namespace DataBaseIndus.Mapper
{
    public class Mapper:Profile
    {
        public Mapper() {
            CreateMap<Tasks, DeleteTaskViewModel>();
            CreateMap<Tasks, EditTask>();
        }
    }
}
