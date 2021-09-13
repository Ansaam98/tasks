using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tasks.BussniseObjects;
using tasks.Models;
using tasks.Resources;
using tasks.Services.TaskService;

namespace tasks.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _TaskService;
        public TaskController(ITaskService TaskService)
        {
            _TaskService = TaskService;

        }



        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TaskResource>>> AddTask(TaskModel newTask)
        {
            var bos = await _TaskService.AddTask(newTask.MapModelToBO(0));
            return Ok(bos.MapBOToResource());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<TaskResource>>> DeleteTask([FromRoute] int id)
        {
            var bos = await _TaskService.DeleteTask(id);
            return Ok(bos);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<TaskResource>>>> GetAllTask()
        {
            return Ok(await _TaskService.GetAllTask());
        }

        [HttpGet("{TaskDate}/TaskDate")]
         public async Task<ActionResult<ServiceResponse<List<TaskResource>>>> GetTaskByDate([FromRoute] DateTimeOffset TaskDate)
         {

             return Ok(await _TaskService.GetTaskByDate(TaskDate));
         }

         [HttpGet("{TaskStatus}/Status")]
         public async Task<ActionResult<ServiceResponse<List<TaskResource>>>> GetTaskByStatus([FromRoute] Status TaskStatus)
         {
             return Ok(await _TaskService.GetTaskByStatus(TaskStatus));
         }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<TaskResource>>> UpdateTask([FromRoute] int id, TaskModel updateTask)
        {
            var bos = await _TaskService.UpdateTask(updateTask.MapModelToBO(id));
            var result = bos.MapBOToResource();

            if(result == null)
            {
                return NotFound(result);

            }
            return Ok(result);

        }
    }
}