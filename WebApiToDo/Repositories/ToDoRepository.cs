using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiToDo.Models;
using WebApiToDo.Repositories.Interface;

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

        public async Task<List<ToDoModel>> ListAllAsync()
        {
            return await _dbContext.ToDo.ToListAsync();
        }
        public async Task AddItemAsync(ToDoModel toDo)
        {
            await _dbContext.ToDo.AddAsync(toDo);
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Adding item failed: {ex.Message}");
                throw ex;
            }
        }
    }
}
