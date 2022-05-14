using ToDoList.Models;
using System.Xml.Linq;

namespace ToDoList.Data
{
    public class CategoryRepositoryXML : ICategoryRepository
    {
        private string TasksDirectoryPath { get; set; } = Directory.GetCurrentDirectory() + @"/XmlStorage/Tasks.xml";
        private string DirectoryPathCategories { get; set; } = Directory.GetCurrentDirectory() + @"/XmlStorage/Categories.xml";
        public CategoryRepositoryXML()
        {
        }

        public void AddCategory(AddCategory model)
        {
            XDocument CategoriesXML = XDocument.Load(DirectoryPathCategories);
            XElement element = CategoriesXML.Descendants("categories").Descendants("category").LastOrDefault();
            int Id = (int)element.Element("idcategory");
            Id++;
            XElement AddModel = new XElement("category", new XElement("idcategory", $"{Id}"),
                new XElement($"{nameof(model.NameCategory).ToLower()}", $"{model.NameCategory}"));

            CategoriesXML.Element("categories").Add(AddModel);
            CategoriesXML.Save(DirectoryPathCategories);
        }
        public Category GetCategoryTasks(int id)
        {

            XDocument CategoriesXML = XDocument.Load(DirectoryPathCategories);
            XDocument TasksXML = XDocument.Load(TasksDirectoryPath);
            XElement element = CategoriesXML.Descendants("categories").Descendants("category").FirstOrDefault(x => (int)x.Element("idcategory") == id);
            element.Remove();

            Category model = new Category
            {
                IdCategory = (int)element.Element("idcategory"),
                NameCategory = element.Element($"{nameof(model.NameCategory).ToLower()}").Value,
                tasks = (from tasks in TasksXML.Descendants("task")
                        where (int)tasks.Element("categoryid") == id
                        select new Tasks
                        {
                            Id = ((int)tasks.Element("id")),
                            NameTask = tasks.Element("nametask").Value,
                            DeadLine = ParseDateTime((string)tasks.Element("deadline")),
                            CategoryId = (int)tasks.Element("categoryid"),
                            TaskCompleted = (bool)tasks.Element("taskcompleted")
                        }).ToList()
            };


            return model;
        }
        public Category GetCategoryById(int id)
        {
            XDocument CategoriesXML = XDocument.Load(DirectoryPathCategories);
            XElement element = CategoriesXML.Descendants("categories").Descendants("category").FirstOrDefault(x => (int)x.Element("idcategory") == id);
            element.Remove();

            Category model = new Category
            {
                IdCategory = (int)element.Element("idcategory"),
                NameCategory = element.Element($"{nameof(model.NameCategory).ToLower()}").Value
            };

            return model;
        }
        public void DeleteCategory(int id)
        {
            XDocument CategoriesXML = XDocument.Load(DirectoryPathCategories);
            XElement element = CategoriesXML.Descendants("categories").Descendants("category").FirstOrDefault(x => (int)x.Element("idcategory") == id);
            element.Remove();
            CategoriesXML.Save(DirectoryPathCategories);
        }
        public void EditCategory(Category model)
        {
            XDocument CategoriesXML = XDocument.Load(DirectoryPathCategories);
            XElement element = CategoriesXML.Descendants("categories").Descendants("category").FirstOrDefault(x => (int)x.Element("idcategory") == model.IdCategory);
            element.SetElementValue("namecategory", model.NameCategory);
            CategoriesXML.Save(DirectoryPathCategories);
        }
        public List<Category> GetCategories()
        {

            XDocument CategoriesXML = XDocument.Load(DirectoryPathCategories);
            IEnumerable<Category> ListCategory = from categories in CategoriesXML.Descendants("category")
                                                 select new Category
                                                 {
                                                     IdCategory = ((int)categories.Element("idcategory")),
                                                     NameCategory = ((string)categories.Element("namecategory"))
                                                 };

            return ListCategory.ToList();
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
