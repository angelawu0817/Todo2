using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo2.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Todo2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoContext _todoContext;    //ang

        public TodoItemsController(TodoContext todoContext )    //ang
        {
            _todoContext = todoContext;
        }
        
        // GET: api/<TodoItemController>
        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> Get()       //ang變更前public IEnumerable<string> Get() ,此為讀取TodoItem資料表的所有資料列
        {
            return _todoContext.TodoItems;    //ang變更前return new string[] { "value1", "value2" }
        }

        // GET api/<TodoItemController>/5
        [HttpGet("{id}")]
        public ActionResult<TodoItem> GetTodoItem(Guid id)                  //ang變更前public string Get(int id), 此為讀取TodoItem資料表的一筆資料
        {
            var result = _todoContext.TodoItems.Find(id);                        //ang變更前
            if (result == null)                        //ang變更前
            {
                return NotFound("沒有資料");
            }
            return result;                        //ang變更前
        }

        // POST api/<TodoItemController>
        [HttpPost]
        public ActionResult<TodoItem> Post([FromBody] TodoItem todoItem)                      //ang變更前public void Post([FromBody] string value) 
        {
            _todoContext.TodoItems.Add(todoItem);                        //ang變更前
            _todoContext.SaveChanges();                        //ang變更前

            return CreatedAtAction(nameof(Put), new { id = todoItem.Id }, todoItem);                        //ang變更前
        }

        // PUT api/<TodoItemController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] TodoItem todoItem)                       //ang變更前public void Put(int id, [FromBody] string value) 
        {
            if (id != todoItem.Id)                                              //ang整段方法內容都是新增加的程式碼
            {
                return BadRequest();
            }

            _todoContext.Entry(todoItem).State = EntityState.Modified;

            try
            {
                _todoContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_todoContext.TodoItems.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(500, "存取發生錯誤");
                }
            }
            return NoContent();
        }

        // DELETE api/<TodoItemController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)                     //ang變更前public void Delete(int id) 
        {
            //以下整段程式碼均為新增程式
            var result = _todoContext.TodoItems.Find(id);

            if (result == null)
            {
                return NotFound();
            }

            _todoContext.TodoItems.Remove(result);
            _todoContext.SaveChanges();

            return NoContent();
        }
    }
}
