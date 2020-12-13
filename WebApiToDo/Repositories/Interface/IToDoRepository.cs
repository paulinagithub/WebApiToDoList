using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiToDo.Models;

namespace WebApiToDo.Repositories.Interface
{
    public interface IToDoRepository
    {
        Task<List<ToDoModel>> ListAllAsync();
        Task AddItemAsync(ToDoModel toDo);
        Task DeleteItemAsync(ToDoModel toDo);
        Task<ToDoModel> FindItemByIDAsync(int id);
        Task UpdateToDoAsync(ToDoModel todo);
        Task<List<ToDoModel>> ListAllItemsFilterAsync(int isCompleted);
    }
}
