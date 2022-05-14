using ToDoList.Models;
using System.Xml.Linq;

namespace ToDoList.Data
{
    public class TaskRepositoryXML : ITaskRepository
    {
        private string TasksDirectoryPath { get; set; } = Directory.GetCurrentDirectory() + @"/XmlStorage/Tasks.xml";
        private string CategoriesDirectoryPath { get; set; } = Directory.GetCurrentDirectory() + @"/XmlStorage/Categories.xml";

        public TaskRepositoryXML()
        {
        }
        public TaskRepositoryXML(string taskfile, string categoryfile)
        {
            TasksDirectoryPath = "@/XmlStorage/" + taskfile;
            CategoriesDirectoryPath = @"/XmlStorage/" + categoryfile;
        }

        public void AddTask(AddTask model)
        {
            XDocument TasksXML = XDocument.Load(TasksDirectoryPath);
            XElement element = TasksXML.Descendants("tasks").Descendants("task").Last();
            int Id = (int)element.Element("id");
            Id++;
            XElement AddModel = new XElement("task", new XElement("id", $"{Id}"),
                new XElement($"{nameof(model.NameTask).ToLower()}", $"{model.NameTask}"),
                new XElement($"{nameof(model.TaskCompleted).ToLower()}", $"{model.TaskCompleted}"),
                new XElement($"{nameof(model.DeadLine).ToLower()}", $"{model.DeadLine}"),
                new XElement($"{nameof(model.CategoryId).ToLower()}", $"{model.CategoryId}"));

            TasksXML.Element("tasks").Add(AddModel);
            TasksXML.Save(TasksDirectoryPath);
        }
        public List<Tasks> GetTasks(int? mode = 0)
        {
            XDocument TasksXML = XDocument.Load(TasksDirectoryPath);
            XDocument CategoriesXML = XDocument.Load(CategoriesDirectoryPath);
            IEnumerable<Tasks> ListTasks = from tasks in TasksXML.Descendants("task")
                                           join categories in CategoriesXML.Descendants("category")
                                           on (int)tasks.Element("categoryid") equals (int)categories.Element("idcategory")
                                           orderby ParseDateTime((string)tasks.Element("deadline")) ascending
                                           orderby ParseDateTime((string)tasks.Element("deadline")) == null ascending

                                           select new Tasks
                                           {
                                               Id = ((int)tasks.Element("id")),
                                               NameTask = tasks.Element("nametask").Value,
                                               DeadLine = ParseDateTime((string)tasks.Element("deadline")),
                                               CategoryId = (int)tasks.Element("categoryid"),
                                               TaskCompleted = (bool)tasks.Element("taskcompleted"),
                                               NameCategory = categories.Element("namecategory").Value
                                           };
            List<Tasks> model = ListTasks.ToList();
            /* ORDER BY case when DeadLine is null then 1 else 0 end, DeadLine asc*/
            return model;
        }
        public Tasks GetTaskId(int? id)
        {
            XDocument TasksXML = XDocument.Load(TasksDirectoryPath);
            XDocument CategoriesXML = XDocument.Load(CategoriesDirectoryPath);
            IEnumerable<Tasks> ListTasks = from tasks in TasksXML.Descendants("task")
                                           where (int)tasks.Element("id") == id
                                           join categories in CategoriesXML.Descendants("category")
                                           on (int)tasks.Element("categoryid") equals (int)categories.Element("idcategory")
                                           select new Tasks
                                           {
                                               Id = (int)tasks.Element("id"),
                                               NameTask = (string)tasks.Element("nametask"),
                                               DeadLine = ParseDateTime((string)tasks.Element("deadline")),
                                               CategoryId = (int)tasks.Element("categoryid"),
                                               TaskCompleted = (bool)tasks.Element("taskcompleted"),
                                               NameCategory = (string)categories.Element("namecategory")
                                           };
            Tasks model = ListTasks.First();
            return model;
        }
        public int UpdateTask(EditTask model)
        {
            XDocument TasksXML = XDocument.Load(TasksDirectoryPath);
            XElement element = TasksXML.Descendants("tasks").Descendants("task").FirstOrDefault(x => (int)x.Element("id") == model.Id);
            element.SetElementValue($"{nameof(model.NameTask).ToLower()}", model.NameTask);
            int TaskCompleted = 0;
            if (model.TaskCompleted) { TaskCompleted = 1; }
            element.SetElementValue($"{nameof(model.TaskCompleted).ToLower()}", model.TaskCompleted);
            element.SetElementValue($"{nameof(model.CategoryId).ToLower()}", model.CategoryId);
            element.SetElementValue($"{nameof(model.DeadLine).ToLower()}", model.DeadLine.ToString());
            TasksXML.Save(TasksDirectoryPath);
            return 1;
        }
        public void DeleteTask(int? id)
        {
            XDocument TasksXML = XDocument.Load(TasksDirectoryPath);
            var element = (from x in TasksXML.Descendants("tasks").Descendants("task")
                           where (int)(x.Element("id")) == id
                           select x);
            element.Remove();
            TasksXML.Save(TasksDirectoryPath);
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
