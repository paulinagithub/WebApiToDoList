using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiToDo.Models;
using WebApiToDo.Repositories.Interfaces;

namespace WebApiToDo.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ToDoDBContext _dbContext;
        private readonly ILogger<ToDoRepository> _logger;
        
        public ToDoRepository(ToDoDBContext dbContext, ILogger<ToDoRepository> logger)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<List<ToDoModel>> GetAllAsync()
        {
            return await _dbContext.ToDo.ToListAsync();
        }

        public async Task<List<ToDoModel>> GetAllItemsFilterAsync(int isCompleted)
        {
            return await _dbContext.ToDo.Where(w => w.IsCompleted == isCompleted).ToListAsync();
        }

        public async Task AddItemAsync(ToDoModel toDo)
        {
            try
            {
                await _dbContext.ToDo.AddAsync(toDo);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Adding item failed: {ex.Message}");
                throw ex;
            }
        }

        public async Task DeleteItemAsync(ToDoModel toDo)
        {
            try
            {
                _dbContext.ToDo.Remove(toDo);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Delete item failed: {ex.Message}");
                throw ex;
            }
        }

        public async Task<ToDoModel> FindItemByIDAsync(int id)
        {
            return await _dbContext.ToDo.FindAsync(id);
        }

        public async Task UpdateToDoAsync(ToDoModel todo)
        {
            try
            {
                _dbContext.ToDo.Update(todo);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Update item failed: {ex.Message}");
                throw ex;
            }
        }
    }
}
