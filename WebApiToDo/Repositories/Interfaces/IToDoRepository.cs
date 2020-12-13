using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiToDo.Models;

namespace WebApiToDo.Repositories.Interfaces
{
    public interface IToDoRepository
    {
        /// <summary>
        /// Return list with all items
        /// </summary>
        Task<List<ToDoModel>> GetAllAsync();
        /// <summary>
        /// Add item to DB
        /// </summary>
        /// <param name="toDo"></param>
        Task AddItemAsync(ToDoModel toDo);
        /// <summary>
        /// Remove item from DB
        /// </summary>
        /// <param name="toDo"></param>
        Task DeleteItemAsync(ToDoModel toDo);
        /// <summary>
        /// Check if item is in DB
        /// </summary>
        /// <param name="id"></param>
        Task<ToDoModel> FindItemByIDAsync(int id);
        /// <summary>
        /// Update item in DB
        /// </summary>
        /// <param name="todo"></param>
        Task UpdateToDoAsync(ToDoModel todo);
        /// <summary>
        /// Return list of all elements filter by given parameters 
        /// </summary>
        /// <param name="isCompleted"></param>
        Task<List<ToDoModel>> GetAllItemsFilterAsync(int isCompleted);
    }
}
