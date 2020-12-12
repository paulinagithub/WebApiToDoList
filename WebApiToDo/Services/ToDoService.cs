using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiToDo.Models;
using WebApiToDo.Repositories.Interface;
using WebApiToDo.Services.Interface;

namespace WebApiToDo.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _toDoRepository;
        public ToDoService(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository ?? throw new ArgumentNullException(nameof(toDoRepository));
        }

        public async Task<List<ToDoModel>> GetAllAsync()
        {
            return await _toDoRepository.ListAllAsync();

        }
        public async Task AddItemAsync(ToDoModel todoModel)
        {
            await _toDoRepository.AddItemAsync(todoModel);
        }
    }
}
