using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiToDo.ModelsDTO;

namespace WebApiToDo.Services.Interface
{
    public interface IToDoService
    {
        Task AddItemAsync(ToDoDTO todoModel);
        Task<bool> DeleteItemAsync(int id);
        Task<List<ToDoDTO>> GetAllAsync();
        Task<List<ToDoDTO>> GetAllItemsFilterAsync(bool isCompleted);
        Task UpdateItemAsync(int id, ToDoDTO todo);
    }
}
