using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Models;
using TaskManagerAPI.Services;

namespace TaskManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        #region Definitions
        public TaskService _service  = new TaskService();
        #endregion
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpPost]
        public IActionResult Create(TaskItem task)
        {
            _service.Create(task);
           return CreatedAtAction(nameof(_service.GetByID), new { id = task.Id }, task);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id) 
        {
            return Ok(_service.GetByID(id));
        }

        [HttpPut("{id}/complete")]
        public IActionResult CompleteTask(int id)
        {
           var result = _service.CompleteTask(id);

            if (!result)
            {
                return NotFound("Tarea no encontrada");
            }

            return Ok(_service.GetByID(id));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var result = _service.DeleteTask(id);

            if (!result)
            {
                return NotFound("Tarea no encontrada");
            }

            return NoContent();
        }
    }
}
