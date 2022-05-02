using Microsoft.AspNetCore.Mvc;
using DataBaseIndus.Data;
using DataBaseIndus.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace DataBaseIndus.Controllers
{
    public class ListController : Controller
    {
        private readonly IConfiguration _configuration;
        public ICategoryRepository CategoryConnection { get; set; }
        public ITaskRepository TaskConnection { get; set; }
        public ListController(IConfiguration configuration, ITaskRepository taskRepository, ICategoryRepository categoryRepository)
        {
            _configuration = configuration;
            TaskConnection = taskRepository;
            CategoryConnection = categoryRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = TaskConnection.GetTasks();
            return View("ListTasks", model);
        }
        [HttpGet]
        public IActionResult CreateTask()
        {
            var model = new ViewModel();
            model.Categories = CategoryConnection.GetCategories();
            return View("AddCategory", model);
        }
        [HttpPost]
        public IActionResult CreateTask(ViewModel task)
        {

            if (task.Addtask.IsValid())
            {
                TaskConnection.AddTask(task.Addtask);
                return RedirectToAction("Index");
            }
            else
            {
                var model = new ViewModel();
                model.Categories = CategoryConnection.GetCategories();
                return View("AddCategory", model);
            }
        }
        [HttpGet]
        public IActionResult EditTask(int id)
        {
            ViewModel model = new ViewModel();
            model.Task = TaskConnection.GetTaskId(id);
            model.Categories = CategoryConnection.GetCategories();
            EditTask edittask = new EditTask();
            edittask.NameTask = model.Task.NameTask;
            edittask.Id = id;
            edittask.TaskCompleted = model.Task.TaskCompleted;
            edittask.CategoryId = model.Task.CategoryId;
            edittask.DeadLine = model.Task.DeadLine;
            model.EditModel = edittask;
            return View("EditTaskForm", model);
        }
        [HttpPost]
        public IActionResult EditTask(ViewModel model)
        {
            TaskConnection.UpdateTask(model.EditModel);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DeleteTask(int id) {
            if (id != 0)
            {
                TaskConnection.DeleteTask(id);
            }
            return RedirectToAction("Index");
        }
        public IActionResult ChangeStatusDone(string message,int? id) {
            if (id != null) {
                Tasks model = TaskConnection.GetTaskId(id);
                if (model.TaskCompleted == 1) {
                    model.TaskCompleted = 0;
                }else
                if (model.TaskCompleted == 0) {
                    model.TaskCompleted = 1;
                }
           TaskConnection.UpdateTask(new EditTask { Id = model.Id, TaskCompleted = model.TaskCompleted, DeadLine = model.DeadLine, NameTask = model.NameTask, CategoryId = model.CategoryId });  }
            return Redirect(message);
        }
        public IActionResult GetDoneOrUnDoneTask(int? mode) {
            var model = TaskConnection.GetTasks();
            if (mode == 1) { 
            model = TaskConnection.GetTasks(1);
            }
            if (mode == 2) {
            model = TaskConnection.GetTasks(2);
            }
            return View("ListTasks", model);
        }
    }
}
