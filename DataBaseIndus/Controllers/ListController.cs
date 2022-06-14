using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ToDoList.Enums;
using ToDoList.Models.DbModel;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ListController : Controller
    {
        private readonly IConfiguration configuration;
        public ICategoryRepository categoryRepository { get; set; }
        public IMapper Mapper { get; set; }
        public ITodoRepository taskRepository { get; set; }
        public ListController(IMapper mapper, IConfiguration configuration,IServiceProvider service)
        {

            CurrentRepository.ChangeRepository(service, CurrentRepository.currentSource);
            this.configuration = configuration;
            categoryRepository = CurrentRepository.categoryRepository;
            taskRepository = CurrentRepository.taskRepository;
            Mapper = mapper;
        }
        [HttpPost]
        public IActionResult ChangeSource(typeSource typeSource)
        {
            CurrentRepository.currentSource = typeSource;

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Index()
        {
         
            ViewModel model = new ViewModel
            {
                Tasks = taskRepository.GetTasks(),
                categoryViewModels = Mapper.Map<List<CategoryViewModel>>(categoryRepository.GetCategories())
            };
            return View("ListTasks",model);
        }
        [HttpPost]
        public IActionResult CreateTodo(CreateTodoModel model)
        {

          /*  if (ModelState.IsValid)
            {*/
                taskRepository.CreateTask(Mapper.Map<TodoModel>(model));
                return RedirectToAction("Index");
           // }
          /*  else
            {*/
                ViewModel Model = new ViewModel
                {
                    Tasks = taskRepository.GetTasks(),
                    Categories = categoryRepository.GetCategories()
                };
                return View("ListTasks", Model);
            //}
        }
        [HttpGet]
        public IActionResult EditTask(int id)
        {
            ViewModel model = new ViewModel();
            model.Categories = categoryRepository.GetCategories();
            model.EditModel = Mapper.Map<EditTodoModel>(taskRepository.GetTaskId(id));
            return View("EditTaskForm", model);
        }
        [HttpPost]
        public IActionResult EditTask(EditTodoModel model)
        {
            if (ModelState.IsValid)
            {
                taskRepository.UpdateTask(Mapper.Map<TodoModel>(model));
            }
            return RedirectToAction("Index");
        }
        public IActionResult DeleteTask(int? id)
        {
            DeleteTodoViewModel model = Mapper.Map<DeleteTodoViewModel>(taskRepository.GetTaskId(id));
            return View("DeleteTask", model);
        }
        [HttpPost]
        public IActionResult DeleteTask(int id)
        {
            taskRepository.DeleteTask(id);
            return RedirectToAction("Index");
        }
        public IActionResult ChangeStatusDone(string message, int? id)
        {
            if (id != null)
            {
                TodoModel model = taskRepository.GetTaskId(id);
                model.TaskCompleted = !model.TaskCompleted;
                taskRepository.UpdateTask(model);
            }
            return Redirect(message);
        }
        
    }
}
