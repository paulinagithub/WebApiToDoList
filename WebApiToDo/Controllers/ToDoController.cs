using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiToDo.ModelsDTO;
using WebApiToDo.Services.Interfaces;

namespace WebApiToDo.Controllers
{
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _toDoService;

        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet]
        [Route("/todo")]
        public async Task<ActionResult<IEnumerable<ToDoDTO>>> GetAllItemsAsync()
        {
            var result = await _toDoService.GetAllItemsAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("/todo/{isCompleted}")]
        public async Task<ActionResult<IEnumerable<ToDoDTO>>> GetAllItemsFilterAsync(bool isCompleted)
        {
            var result = await _toDoService.GetAllItemsFilterAsync(isCompleted);
            return Ok(result);
        }

        [HttpPost]
        [Route("/todo")]
        public async Task<ActionResult> AddItemAsync(ToDoDTO toDoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            await _toDoService.AddItemAsync(toDoDTO);
            return Ok(toDoDTO);         
        }

        [HttpDelete]
        [Route("/todo/{id}")]
        public async Task<ActionResult> DeleteItemAsync(int id)
        {
            var result = await _toDoService.DeleteItemAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok();        
        }

        [HttpPut]
        [Route("/todo/{id}")]
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
