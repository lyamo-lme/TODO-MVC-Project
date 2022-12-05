using Microsoft.AspNetCore.Mvc;
using ToDoList.Data;
using ToDoList.Models.DbModel;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route(@"api\todo")]
    public class TodoController:Controller
    {
        private ITodoRepository TodoRepository { get; set; }

        public  TodoController(ITodoRepository repository)
        {
            TodoRepository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TodoModel>>> GetTodos()
        {
            return await TodoRepository.GetTasks();
        }
        [HttpDelete, Route("delete")]
        public  ActionResult<int> Delete(int id)
        {
            return  TodoRepository.DeleteTask(id);
        }
        
        [HttpPost, Route("create")]
        public  ActionResult<TodoModel?> Create([FromBody] TodoModel todo)
        {
            return  TodoRepository.CreateTask(todo);
        }
        
        [HttpPost, Route("update")]
        public  ActionResult<TodoModel> Update([FromBody] TodoModel todo)
        {
            return  TodoRepository.UpdateTask(todo);
        }
    }
}