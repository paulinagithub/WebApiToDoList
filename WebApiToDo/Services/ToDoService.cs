using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiToDo.Models;
using WebApiToDo.ModelsDTO;
using WebApiToDo.Repositories.Interfaces;
using WebApiToDo.Services.Interfaces;

namespace WebApiToDo.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _toDoRepository;
        private readonly IMapper _mapper;

        public ToDoService(IToDoRepository toDoRepository, IMapper mapper)
        {
            _toDoRepository = toDoRepository ?? throw new ArgumentNullException(nameof(toDoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }

        public async Task<List<ToDoDTO>> GetAllAsync()
        {
            var toDoList = await _toDoRepository.ListAllAsync();
            return _mapper.Map<List<ToDoDTO>>(toDoList);
        }

        public async Task<List<ToDoDTO>> GetAllItemsFilterAsync(bool isCompleted)
        {
            var toDoList = await _toDoRepository.ListAllItemsFilterAsync(ConvertBoolToInt(isCompleted));
            return _mapper.Map<List<ToDoDTO>>(toDoList);
        }

        public async Task AddItemAsync(ToDoDTO todoModel)
        {
            var toDoModel = _mapper.Map<ToDoModel>(todoModel);
            await _toDoRepository.AddItemAsync(toDoModel);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var toDo = await _toDoRepository.FindItemByIDAsync(id);
            if (toDo == null)
            {
                return false;
            }
            await _toDoRepository.DeleteItemAsync(toDo);
            return true;
        }

        public async Task UpdateItemAsync(int id, ToDoDTO todo)
        {
            var toDoModel = _mapper.Map<ToDoModel>(todo);
            toDoModel.Id = id;
            await _toDoRepository.UpdateToDoAsync(toDoModel);
        }

        private int ConvertBoolToInt(bool boolValue)
        {
            return Convert.ToInt32(boolValue);
        }
    }
}
