using AutoMapper;
using ToDoList.Data;
using ToDoList.Models;
using Microsoft.AspNetCore.Mvc;
using DataBaseIndus.Data;

namespace ToDoList.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IConfiguration configuration;
        public ICategoryRepository categoryRepository { get; set; }
        public ITaskRepository taskRepository { get; set; }
        IMapper Mapper { get; set; }

        public CategoryController(IMapper mapper, IConfiguration configuration, IServiceProvider serviceProvider)
        {
            CurrentRepository.Initialization(serviceProvider, CurrentRepository.currentSource);
            this.configuration = configuration;
            categoryRepository = CurrentRepository.categoryRepository;
            taskRepository = CurrentRepository.taskRepository;
            Mapper = mapper;
        }
        public IActionResult Index()
        {
            List<Category> Categories = categoryRepository.GetCategories();
            //Mapper.Map<List<CategoryViewModel>>(CategoryConnection.GetCategories());
            return View("ListCategories", Categories);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View("AddCategoryForm");
        }
        [HttpPost]
        public IActionResult AddCategory(AddCategory model)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.AddCategory(model);
                return RedirectToAction("Index");
            }
            return View("AddCategoryForm");

        }
        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            return View("EditCategoryForm", categoryRepository.GetCategoryById(id) /*Mapper.Map<CategoryViewModel>(CategoryConnection.GetCategoryById(id))*/);
        }
        [HttpPost]
        public IActionResult EditCategory(Category model)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.EditCategory(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View("EditCategoryForm", model);
            }
        }
        public IActionResult CategoryWithTasks(int id = 0)
        {
            if (id != 0)
            {
                Category category = categoryRepository.GetCategoryTasks(id);
                return View("CategoryWithTasks", category);
            }
            return RedirectToAction("Index");
        }
        public IActionResult DeleteCategory(int id = 0)
        {
            try
            {
                if (id != 0)
                {
                    categoryRepository.DeleteCategory(id);
                }
            }
            catch
            {
                return View("Views/Error.cshtml", new Error("Не можна видалити поки є завдання повязанні з цією категорією"));
            }
            return RedirectToAction("Index");
        }
    }
}
