using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using tasks.BussniseObjects;
using tasks.Models;

namespace tasks.Services.TaskService
{
    public interface ITaskService
    {
        Task<List<TaskBO>> GetAllTask();
         Task<List<TaskBO>> GetTaskByDate(DateTimeOffset TaskDate);
         Task<List<TaskBO>> GetTaskByStatus(Status TaskStatus);
         Task<TaskBO> AddTask(TaskBO newTask);
         Task<TaskBO> UpdateTask(TaskBO updateTask);
         Task<TaskBO> DeleteTask(int id); 
    }
}