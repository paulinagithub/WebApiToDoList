using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiToDo.Models;
using WebApiToDo.Services.Interface;

namespace WebApiToDo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _toDoService;

        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        // GET: api/ToDo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoModel>>> GetToDo()
        {
            return await _toDoService.GetAllAsync();
        }

        // POST: api/ToDo
        [HttpPost]
        public async Task<ActionResult<ToDoModel>> AddItem(ToDoModel toDo)
        {
            await _toDoService.AddItemAsync(toDo);

            return toDo;
        }

       // DELETE: api/ToDo/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<ToDoModel>> DeleteToDo(int id)
        //{
        //    var toDo = await _toDoService.ToDo.FindAsync(id);
        //    if (toDo == null)
        //    {
        //        return NotFound();
        //    }

        //    _toDoService.ToDo.Remove(toDo);
        //    await _toDoService.SaveChangesAsync();

        //    return toDo;
        //}

        //    // GET: api/ToDo/5
        //    [HttpGet("{id}")]
        //    public async Task<ActionResult<ToDo>> GetToDo(int id)
        //    {
        //        var toDo = await _toDoService.ToDo.FindAsync(id);

        //        if (toDo == null)
        //        {
        //            return NotFound();
        //        }

        //        return toDo;
        //    }

        //    // PUT: api/ToDo/5
        //    // To protect from overposting attacks, enable the specific properties you want to bind to, for
        //    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> PutToDo(int id, ToDo toDo)
        //    {
        //        if (id != toDo.Id)
        //        {
        //            return BadRequest();
        //        }

        //        _toDoService.Entry(toDo).State = EntityState.Modified;

        //        try
        //        {
        //            await _toDoService.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ToDoExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return NoContent();
        //    }





        //    private bool ToDoExists(int id)
        //    {
        //        return _toDoService.ToDo.Any(e => e.Id == id);
        //    }
    }
}
