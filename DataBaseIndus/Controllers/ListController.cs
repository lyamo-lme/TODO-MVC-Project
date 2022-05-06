using Microsoft.AspNetCore.Mvc;
using DataBaseIndus.Data;
using DataBaseIndus.Models;
using AutoMapper;



namespace DataBaseIndus.Controllers
{
    public class ListController : Controller
    {
        private readonly IConfiguration Configuration;
        public ICategoryRepository CategoryConnection { get; set; }
        public IMapper Mapper { get; set; }
        public ITaskRepository TaskConnection { get; set; }
        public ListController(IMapper mapper,IConfiguration configuration, ITaskRepository taskRepository, ICategoryRepository categoryRepository)
        {
            Configuration = configuration;
            TaskConnection = taskRepository;
            CategoryConnection = categoryRepository;
            Mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            /* TaskRepositoryXML model1 = new TaskRepositoryXML();
             TaskConnection = model1;*/
            ViewModel model = new ViewModel
            {
                Tasks = TaskConnection.GetTasks(),
                Categories = CategoryConnection.GetCategories()
            };
            return View("ListTasks", model);
        }
        [HttpPost]
        public IActionResult CreateTask(ViewModel model)
        {

            if (model.AddTask.IsValid())
            {
                TaskConnection.AddTask(model.AddTask);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.Clear();
                ModelState.AddModelError("AddTask.NameTask", "Validation name");
                model = new ViewModel
                {
                    Tasks = TaskConnection.GetTasks(),
                    Categories = CategoryConnection.GetCategories()
                };
                return View("ListTasks", model);
            }
        }
        [HttpGet]
        public IActionResult EditTask(int id)
        {
            ViewModel model = new ViewModel();
             model.Categories = CategoryConnection.GetCategories();
           /*  EditTask edittask = new EditTask();
             edittask.NameTask = model.Task.NameTask;
             edittask.Id = id;
             edittask.TaskCompleted = model.Task.TaskCompleted;
             edittask.CategoryId = model.Task.CategoryId;
             edittask.DeadLine = model.Task.DeadLine;
             model.EditModel = edittask;*/
            model.EditModel = Mapper.Map<EditTask>(TaskConnection.GetTaskId(id));
            return View("EditTaskForm", model);
        }
        [HttpPost]
        public IActionResult EditTask(ViewModel model)
        {
            TaskConnection.UpdateTask(model.EditModel);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteTask(int? id)
        {
            DeleteTaskViewModel model = Mapper.Map<DeleteTaskViewModel>(TaskConnection.GetTaskId(id));
            return View("DeleteTask", model);
        }
        [HttpPost]
        public IActionResult DeleteTask(int id)
        {
            TaskConnection.DeleteTask(id);
            return RedirectToAction("Index");
        }
        public IActionResult ChangeStatusDone(string message, int? id)
        {
            if (id != null)
            {
                Tasks model = TaskConnection.GetTaskId(id);
                model.TaskCompleted = !model.TaskCompleted;
                TaskConnection.UpdateTask(new EditTask { Id = model.Id, TaskCompleted = model.TaskCompleted, DeadLine = model.DeadLine, NameTask = model.NameTask, CategoryId = model.CategoryId });
            }
            return Redirect(message);
        }
        public IActionResult GetDoneOrUnDoneTask(int? mode)
        {
            var model = TaskConnection.GetTasks();
            if (mode == 1)
            {
                model = TaskConnection.GetTasks(1);
            }
            if (mode == 2)
            {
                model = TaskConnection.GetTasks(2);
            }
            return View("ListTasks", model);
        }
    }
}
