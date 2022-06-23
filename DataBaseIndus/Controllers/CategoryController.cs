using AutoMapper;
using ToDoList.Data;
using ToDoList.Models;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models.DbModel;

namespace ToDoList.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IConfiguration configuration;
        public ICategoryRepository categoryRepository { get; set; }
        public ITodoRepository taskRepository { get; set; }
        IMapper Mapper { get; set; }

        public CategoryController(IMapper mapper, IConfiguration configuration, IServiceProvider serviceProvider)
        {
            CurrentRepository.ChangeRepository(serviceProvider, CurrentRepository.currentSource);
            this.configuration = configuration;
            categoryRepository = CurrentRepository.categoryRepository;
            taskRepository = CurrentRepository.taskRepository;
            Mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            List<Category> Categories = await categoryRepository.GetCategories();
            //Mapper.Map<List<CategoryViewModel>>(CategoryConnection.GetCategories());
            return View("ListCategories", Categories);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View("AddCategoryForm");
        }
        [HttpPost]
        public IActionResult AddCategory(CreateCategory model)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.CreateCategory(Mapper.Map<Category>(model));
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
        public async Task<IActionResult> CategoryWithTasks(int id = 0)
        {
            if (id != 0)
            {
                Category category = await categoryRepository.GetCategoryTasks(id);
                return View("CategoryWithTasks", category);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteCategory(int id = 0)
        {
            int i=0;
            if (id != 0)
            {
                i = await categoryRepository.DeleteCategory(id);
            }
            if (i == 0)
            return View("Views/Error.cshtml", new { error = "Не можна видалити поки є завдання повязанні з цією категорією" });

            return RedirectToAction("Index");
        }
    }
}
