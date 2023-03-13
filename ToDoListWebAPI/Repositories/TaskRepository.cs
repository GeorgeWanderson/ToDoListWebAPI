using Microsoft.EntityFrameworkCore;
using ToDoListWebAPI.Data;
using ToDoListWebAPI.Models;
using ToDoListWebAPI.Repositories.Interfaces;

namespace ToDoListWebAPI.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TasksDBContext _dbContext;
        public TaskRepository(TasksDBContext tasksDBContext)
        {
            _dbContext = tasksDBContext;
        }
        public async Task<TaskModel> GetById(int id)
        {

            return await _dbContext.Tasks.Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<TaskModel>> GetAllTasks()
        {
            return await _dbContext.Tasks.Include(x => x.User).ToListAsync();
        }
        public async Task<TaskModel> Add(TaskModel task)
        {
            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();

            return task;
        }
        public async Task<TaskModel> Update(TaskModel task, int id)
        {
            TaskModel taskById = await GetById(id);

            if (taskById == null)
            {
                throw new Exception($"Task para o ID: {id} Não foi encontrado no banco de dados.");
            }

            taskById.Name = task.Name;
            taskById.Description = task.Description;
            taskById.Status = task.Status;
            taskById.UserId = task.UserId;

            _dbContext.Tasks.Update(taskById);
            await _dbContext.SaveChangesAsync();

            return taskById;
        }

        public async Task<bool> DeleteById(int id)
        {
            TaskModel taskById = await GetById(id);

            if (taskById == null)
            {
                throw new Exception($"Tasks para o ID: {id} Não foi encontrado no banco de dados.");
            }

            _dbContext.Tasks.Remove(taskById);
            await _dbContext.SaveChangesAsync();
            return true;


        }
    }
}


