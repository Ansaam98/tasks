using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using tasks.BussniseObjects;
using tasks.Data;
using tasks.Models;

namespace tasks.Services.TaskService
{
    public class TaskService : ITaskService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TaskService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;

        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));


        public async Task<TaskBO> AddTask(TaskBO newTask)
        {
            var task = newTask.MapBOToEntity();
            task.User = await _context.Users.FirstOrDefaultAsync(u => u.id == GetUserId());
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            var dbTask = await _context.Tasks.Where(c => c.User.id == GetUserId())
            .FirstOrDefaultAsync(a => a.Id == task.Id);

            return dbTask.MapEntityToBO();
        }

        public async Task<TaskBO> DeleteTask(int id)
        {
            var dbTask = await _context.Tasks.FirstAsync(c => c.Id == id && c.User.id == GetUserId());

            if(dbTask != null)
            {
                _context.Tasks.Remove(dbTask);
                await _context.SaveChangesAsync();
            }

            return dbTask.MapEntityToBO();
        }

        public async Task<List<TaskBO>> GetAllTask()
        {
            var dbTasks = await _context.Tasks.Where(c => c.User.id == GetUserId()).ToListAsync();
            return dbTasks.Select(c => c.MapEntityToBO()).ToList();
        }

        public async Task<List<TaskBO>> GetTaskByDate(DateTimeOffset TasksDate)
        {
            var dbTask = await _context.Tasks
            .Where(c => c.Date.Date == TasksDate.Date && c.User.id == GetUserId())
            .Select(x => x.MapEntityToBO())
            .ToListAsync();
            return dbTask.ToList();
            
        }

        public async Task<List<TaskBO>> GetTaskByStatus(Status TaskStatus)
        {
            var dbTask = await _context.Tasks
            .Where(c => c.Status == TaskStatus && c.User.id == GetUserId())
            .ToListAsync();

            return dbTask.Select(x => x.MapEntityToBO()).ToList();
        }

        public async Task<TaskBO> UpdateTask(TaskBO updateTask)
        {
            var task = updateTask.MapBOToEntity();
            var dbTask = await _context.Tasks
            .Include(c=> c.User)
            .FirstOrDefaultAsync(c => c.Id == updateTask.Id);

            if(dbTask.User.id == GetUserId())
            {
                dbTask.Title = updateTask.Title;
                dbTask.Description = updateTask.Description;
                dbTask.Date = updateTask.Date;
                dbTask.Status = updateTask.Status;

                _context.Update(dbTask);
                await _context.SaveChangesAsync();

            }
            var taskResult = dbTask.MapEntityToBO();
            return taskResult;
        }
    }
}