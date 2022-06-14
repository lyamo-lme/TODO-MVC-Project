using System.Xml.Linq;
using ToDoList.Models.DbModel;

namespace ToDoList.Data
{
    public class TodoRepositoryXML : ITodoRepository
    {
        private string TasksDirectoryPath { get; set; } = Directory.GetCurrentDirectory() + @"/XmlStorage/Todo.xml";
        private string CategoriesDirectoryPath { get; set; } = Directory.GetCurrentDirectory() + @"/XmlStorage/Categories.xml";

        public TodoRepositoryXML()
        {
        }

        public TodoModel CreateTask(TodoModel model)
        {
            XDocument TasksXML = XDocument.Load(TasksDirectoryPath);
            XElement element = TasksXML.Descendants("tasks").Descendants("task").Last();
            int Id = (int)element.Element("id");
            Id++;
            XElement AddModel = new XElement("task", new XElement("id", $"{Id}"),
                new XElement($"{nameof(model.NameTodo).ToLower()}", $"{model.NameTodo}"),
                new XElement($"{nameof(model.TaskCompleted).ToLower()}", $"{model.TaskCompleted}"),
                new XElement($"{nameof(model.DeadLine).ToLower()}", $"{model.DeadLine}"),
                new XElement($"{nameof(model.CategoryId).ToLower()}", $"{model.CategoryId}"));

            TasksXML.Element("tasks").Add(AddModel);
            TasksXML.Save(TasksDirectoryPath);
            return GetTaskId(Id);
        }
        public List<TodoModel> GetTasks(int? mode = 0)
        {
            XDocument TasksXML = XDocument.Load(TasksDirectoryPath);
            XDocument CategoriesXML = XDocument.Load(CategoriesDirectoryPath);
            IEnumerable<TodoModel> ListTasks = from tasks in TasksXML.Descendants("task")
                                           join categories in CategoriesXML.Descendants("category")
                                           on (int)tasks.Element("categoryid") equals (int)categories.Element("idcategory")
                                           orderby ParseDateTime((string)tasks.Element("deadline")) ascending
                                           orderby ParseDateTime((string)tasks.Element("deadline")) == null ascending

                                           select new TodoModel
                                           {
                                               Id = ((int)tasks.Element("id")),
                                               NameTodo = tasks.Element("nametask").Value,
                                               DeadLine = ParseDateTime((string)tasks.Element("deadline")),
                                               CategoryId = (int)tasks.Element("categoryid"),
                                               TaskCompleted = (bool)tasks.Element("taskcompleted"),
                                               NameCategory = categories.Element("namecategory").Value
                                           };
            List<TodoModel> model = ListTasks.ToList();
            return model;
        }
        public TodoModel GetTaskId(int? id)
        {
            XDocument TasksXML = XDocument.Load(TasksDirectoryPath);
            XDocument CategoriesXML = XDocument.Load(CategoriesDirectoryPath);
            IEnumerable<TodoModel> ListTasks = from tasks in TasksXML.Descendants("task")
                                           where (int)tasks.Element("id") == id
                                           join categories in CategoriesXML.Descendants("category")
                                           on (int)tasks.Element("categoryid") equals (int)categories.Element("idcategory")
                                           select new TodoModel
                                           {
                                               Id = (int)tasks.Element("id"),
                                               NameTodo = (string)tasks.Element("nametask"),
                                               DeadLine = ParseDateTime((string)tasks.Element("deadline")),
                                               CategoryId = (int)tasks.Element("categoryid"),
                                               TaskCompleted = (bool)tasks.Element("taskcompleted"),
                                               NameCategory = (string)categories.Element("namecategory")
                                           };
            TodoModel model = ListTasks.First();
            return model;
        }
        public TodoModel UpdateTask(TodoModel model)
        {
            XDocument TasksXML = XDocument.Load(TasksDirectoryPath);
            XElement element = TasksXML.Descendants("tasks").Descendants("task").FirstOrDefault(x => (int)x.Element("id") == model.Id);
            element.SetElementValue($"{nameof(model.NameTodo).ToLower()}", model.NameTodo);
            int TaskCompleted = 0;
            if (model.TaskCompleted) { TaskCompleted = 1; }
            element.SetElementValue($"{nameof(model.TaskCompleted).ToLower()}", TaskCompleted);
            element.SetElementValue($"{nameof(model.CategoryId).ToLower()}", model.CategoryId);
            element.SetElementValue($"{nameof(model.DeadLine).ToLower()}", model.DeadLine.ToString());
            TasksXML.Save(TasksDirectoryPath);
            return GetTaskId(model.Id);
        }
        public int DeleteTask(int? id)
        {
            try { 
            XDocument TasksXML = XDocument.Load(TasksDirectoryPath);
            var element = (from x in TasksXML.Descendants("tasks").Descendants("task")
                           where (int)(x.Element("id")) == id
                           select x);
            element.Remove();
            TasksXML.Save(TasksDirectoryPath);
                return 1;
            }
            catch {
                return 0; 
            }
        }
        public DateTime? ParseDateTime(string time)
        {
            DateTime dateTime = new DateTime();
            if (DateTime.TryParse(time, out dateTime))
            {
                return dateTime;
            }
            return null;
        }
    }
}
