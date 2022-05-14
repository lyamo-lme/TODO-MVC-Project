using DataBaseIndus.Enums;
using ToDoList.Data;

namespace DataBaseIndus.Data
{
    public static class CurrentRepository
    {

        public static ICategoryRepository? categoryRepository { get; set; } = null;
        public static ITaskRepository? taskRepository { get; set; } = null;
        public static typeSource currentSource { get; set; } = typeSource.Db;
        public static IServiceProvider serviceProvider { get; set; }
        public  static void Initialization(IServiceProvider service, typeSource typeSource)
        {
            serviceProvider = service;
            switch (typeSource)
            {
                case typeSource.XML:
                    categoryRepository = service.GetService<CategoryRepositoryXML>();
                    taskRepository = service.GetService<TaskRepositoryXML>();
                    break;
                case typeSource.Db:
                    categoryRepository = service.GetService<CategoryRepository>();
                    taskRepository = service.GetService<TaskRepository>();
                    break;
            }
        }
        public static void Null() {
            categoryRepository = null; 
            taskRepository = null; 
        }
    }
}
