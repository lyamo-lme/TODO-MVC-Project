using Microsoft.AspNetCore.Mvc;
using ToDoList.Data;
using ToDoList.Models;
using AutoMapper;
using DataBaseIndus.Enums;
using DataBaseIndus.Data;

namespace ToDoList.Controllers
{
    public class ListController : Controller
    {
        private readonly IConfiguration configuration;
        public ICategoryRepository categoryRepository { get; set; }
        public IMapper Mapper { get; set; }
        public ITaskRepository taskRepository { get; set; }
        public ListController(IMapper mapper, IConfiguration configuration,IServiceProvider service)
        {

            CurrentRepository.Initialization(service, CurrentRepository.currentSource);
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
                /*Categories = Mapper.Map<List<CategoryViewModel>>(CategoryConnection.GetCategories())*/
                Categories = categoryRepository.GetCategories()
            };
            return View("ListTasks",model);
        }
        [HttpPost]
        public IActionResult CreateTask(AddTask model)
        {

            if (ModelState.IsValid)
            {
                CurrentRepository.taskRepository.AddTask(model);
                return RedirectToAction("Index");
            }
            else
            {
                ViewModel Model = new ViewModel
                {
                    Tasks = taskRepository.GetTasks(),
                    Categories = categoryRepository.GetCategories()
                    /*Categories = Mapper.Map<List<CategoryViewModel>>(CategoryConnection.GetCategories())*/
                };
                return View("ListTasks", Model);
            }
        }
        [HttpGet]
        public IActionResult EditTask(int id)
        {
            ViewModel model = new ViewModel();
            model.Categories = categoryRepository.GetCategories();
            /*Mapper.Map<List<CategoryViewModel>>(CategoryConnection.GetCategories());*/
            model.EditModel = Mapper.Map<EditTask>(taskRepository.GetTaskId(id));
            return View("EditTaskForm", model);
        }
        [HttpPost]
        public IActionResult EditTask(EditTask model)
        {
            if (ModelState.IsValid)
            {
                taskRepository.UpdateTask(model);
            }
            return RedirectToAction("Index");
        }
        public IActionResult DeleteTask(int? id)
        {
            DeleteTaskViewModel model = Mapper.Map<DeleteTaskViewModel>(taskRepository.GetTaskId(id));
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
                Tasks model = taskRepository.GetTaskId(id);
                model.TaskCompleted = !model.TaskCompleted;
                taskRepository.UpdateTask(Mapper.Map<EditTask>(model));
            }
            return Redirect(message);
        }
        
    }
}
