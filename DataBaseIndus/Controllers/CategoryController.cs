using Microsoft.AspNetCore.Mvc;
using ToDoList.Data;
using ToDoList.Models.DbModel;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route(@"api/category")]
    public class CategoryController:Controller
    {
        private ICategoryRepository CategoryRepository { get; set; }

        public  CategoryController(ICategoryRepository category)
        {
            CategoryRepository = category;
        }
        [HttpDelete, Route("delete")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            return await  CategoryRepository.DeleteCategory(id);
        }
        
        [HttpPost, Route("create")]
        public async  Task<ActionResult<Category>> Create([FromBody] Category todo)
        {
            return await  CategoryRepository.CreateCategory(todo);
        }
        
        [HttpPost, Route("update")]
        public async  Task<ActionResult<Category>> Update([FromBody] Category todo)
        {
            try
            {
                return Ok(await CategoryRepository.EditCategory(todo));
            }
            catch
            {
                throw new Exception("u are loh");
            }
        } 
        
        
    }
}