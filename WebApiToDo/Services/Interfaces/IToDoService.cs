using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiToDo.ModelsDTO;

namespace WebApiToDo.Services.Interfaces
{
    public interface IToDoService
    {
        /// <summary>
        /// Add new item
        /// </summary>
        /// <param name="todoModel"></param>
        Task AddItemAsync(ToDoDTO todoModel);

        /// <summary>
        /// Delete item by id
        /// </summary>
        /// <param name="id"></param>
        Task<bool> DeleteItemAsync(int id);

        /// <summary>
        /// Get all item from DB
        /// </summary>
        Task<List<ToDoDTO>> GetAllItemsAsync();

        /// <summary>
        /// Get all item with bool filter isCompleted
        /// </summary>
        /// <param name="isCompleted"></param>
        Task<List<ToDoDTO>> GetAllItemsFilterAsync(bool isCompleted);

        /// <summary>
        /// Update item with new model by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="todo"></param>
        Task UpdateItemAsync(int id, ToDoDTO todo);
    }
}
