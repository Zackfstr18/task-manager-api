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
        public TaskService _service ;

        public TaskController(TaskService service) 
        {
            _service = service;
        }
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _service.GetAllAsync();
            return Ok(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskItem task)
        {
            var createdTask = await _service.CreateAsync(task);

            return CreatedAtAction(
                nameof(GetByID),
                new { id = createdTask.Id },
                createdTask
            );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id) 
        {
            var task = await _service.GetByIdAsync(id);

            if (task == null)
                return NotFound("Tarea no encontrada");

            return Ok(task);
        }

        [HttpPut("{id}/complete")]
        public async Task<IActionResult> CompleteTask(int id)
        {
            var success = await _service.CompleteAsync(id);

            if (!success)
                return NotFound("Tarea no encontrada");

            var updatedTask = await _service.GetByIdAsync(id);
            return Ok(updatedTask);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var success = await _service.DeleteAsync(id);

            if (!success)
                return NotFound("Tarea no encontrada");

            return NoContent();
        }
    }
}
