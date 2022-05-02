using DataBaseIndus.Data;
using DataBaseIndus.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataBaseIndus.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IConfiguration _configuration;
        public ICategoryRepository CategoryConnection { get; set; }
        public ITaskRepository TaskConnection { get; set; }
        public CategoryController(IConfiguration configuration, ITaskRepository taskRepository, ICategoryRepository categoryRepository)
        {
            _configuration = configuration;
            TaskConnection = taskRepository;
            CategoryConnection = categoryRepository;
        }
        public IActionResult Index()
        {
            List<Category> Categories = CategoryConnection.GetCategories();
            return View("ListCategories", Categories);
        }
        [HttpGet]
        public IActionResult AddCategory() {
            return View("AddCategoryForm");
        }
        [HttpPost]
        public IActionResult AddCategory(Category model) {
            if (ModelState.IsValid)
            {
                CategoryConnection.AddCategory(model);
                return RedirectToAction("Index");
            }
            return View("AddCategoryForm");

        }
        [HttpGet]
        public IActionResult EditCategory(int id) {
            Category model = CategoryConnection.GetCategoryTasks(id);
            return View("EditCategoryForm", model);
        }
        [HttpPost]
        public IActionResult EditCategory(Category model) {
            if (ModelState.IsValid)
            {
                CategoryConnection.EditCategory(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View("EditCategoryForm",model);
            }
        }
        public IActionResult CategoryWithTasks(int id = 0)
        {
            if (id != 0)
            {
                Category category = CategoryConnection.GetCategoryTasks(id);
                return View("CategoryWithTasks", category);
            }
            return RedirectToAction("Index");
        }
        public IActionResult DeleteCategory(int id=0) {
            try
            {
                if (id != 0)
                {
                    CategoryConnection.DeleteCategory(id);
                }
            }
            catch(Exception e)
            {
                return View("Views/Error.cshtml", new Error("Не можна видалити поки є завдання повязанні з цією категорією"));
            }
            return RedirectToAction("Index");
        }
    }
}
