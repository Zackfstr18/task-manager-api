using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        #region Definitions
        private static List<TaskItem> tasks = new List<TaskItem>();
        #endregion
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(tasks);
        }

        [HttpPost]
        public IActionResult Create(TaskItem task)
        {
            task.Id = tasks.Count + 1;
            tasks.Add(task);

            return Ok(task);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id) 
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);

            if (task == null) 
            {
                return NotFound("Tarea no Encontrada");
            }

            return Ok(task);
        }
    }
}
