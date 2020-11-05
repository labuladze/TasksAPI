using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksApi.Data;
using TasksApi.Model;

namespace TasksApi.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : ControllerBase
    {
        private ITasks _task;
        public TasksController(ITasks task)
        {
            _task = task;
        }
        // Get request URI api/tasks
        [HttpGet]
        public ActionResult <IEnumerable<Tasks>> GetAllTasks()
        {
            return Ok(_task.GetAllTasks());
        }
        //  Get request URI api/tasks/id
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Tasks>> GetAllTasksByID(int id)
        {
            var data = _task.GetAllTasks();
            IEnumerable<Tasks> result = data.Where(curr => curr.id == id);
            if (!result.Any())
            {
                return NoContent();
            }
            return Ok(result);
        }
    }
}
