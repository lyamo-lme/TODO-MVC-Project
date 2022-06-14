using ToDoList.Enums;
using ToDoList.Data;

namespace ToDoList.Data
{
    public static class CurrentRepository
    {

        public static ICategoryRepository categoryRepository { get; private set; }
        public static ITodoRepository taskRepository { get; private set; }
        public static typeSource currentSource { get; set; } = typeSource.Db;
        private static IServiceProvider serviceProvider { get; set; }
        public  static void ChangeRepository(IServiceProvider service, typeSource typeSource)
        {
            serviceProvider = service;
            switch (typeSource)
            {
                case typeSource.XML:
                    categoryRepository = service.GetService<CategoryRepositoryXML>();
                    taskRepository = service.GetService<TodoRepositoryXML>();
                    break;
                default:
                case typeSource.Db:
                    categoryRepository = service.GetService<CategoryRepository>();
                    taskRepository = service.GetService<TodoRepository>();
                    break;
            }
        }
    }
}
