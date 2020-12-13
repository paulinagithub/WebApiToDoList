using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiToDo.ModelsDTO;
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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoDTO>>> GetAllItemsAsync()
        {
            var result = await _toDoService.GetAllAsync();
            return Ok(result);
        }
        [HttpGet("{isCompleted}", Name = "byFilter")]
        public async Task<ActionResult<IEnumerable<ToDoDTO>>> GetAllItemsFilterAsync(bool isCompleted)
        {
            var result = await _toDoService.GetAllItemsFilterAsync(isCompleted);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult> AddItemAsync(ToDoDTO toDoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            await _toDoService.AddItemAsync(toDoDTO);
            return Ok(toDoDTO);
          
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItemAsync(int id)
        {
            var result = await _toDoService.DeleteItemAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItemAsync(int id, ToDoDTO toDoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }       
            await _toDoService.UpdateItemAsync(id, toDoDTO);
            return Ok(toDoDTO);           
        }
    }
}
