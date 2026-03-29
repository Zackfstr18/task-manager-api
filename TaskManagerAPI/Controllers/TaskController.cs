using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using TaskManagerAPI.Mappings;
using TaskManagerAPI.Models;
using TaskManagerAPI.Models.DTOs;
using TaskManagerAPI.Models.Entities;
using TaskManagerAPI.Models.Responses;
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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationParams pagination)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var (items, totalCount) = await _service.GetAllAsync(pagination, userId);

            var dtoItems = items.Select(t => t.toDto());

            var response = new PagedResponse<TaskResponseDto>
            {
                Items = dtoItems,
                TotalCount = totalCount,
                Page = pagination.Page,
                PageSize = pagination.PageSize,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pagination.PageSize)
            };

            return Ok(response);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskDto dto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var task = new TaskItem
            {
                Title = dto.Title,
                Description = dto.Description,
                IsCompleted = false,
                UserId = userId
            };

            var createdTask = await _service.CreateAsync(task);

            return CreatedAtAction(
                nameof(GetByID),
                new { id = createdTask.Id },
                new ApiResponse<TaskItem>
                {
                    Success = true,
                    Message = "Tarea creada correctamente",
                    Data = createdTask
                }
            );
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id) 
        {
            var task = await _service.GetByIdAsync(id);

            if (task == null)
            {
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Tarea no encontrada"
                });
            }

            return Ok(new ApiResponse<TaskItem>
            {
                Success = true,
                Message = "Tarea obtenida correctamente",
                Data = task
            });
        }

        [Authorize]
        [HttpPut("{id}/complete")]
        public async Task<IActionResult> CompleteTask(int id)
        {
            var success = await _service.CompleteAsync(id);

            if (!success)
            {
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Error marcando tarea como completada."
                });
            }

            var updatedTask = await _service.GetByIdAsync(id);
            return Ok(new ApiResponse<TaskItem>
            {
                Success = true,
                Message = "Tarea completada.",
                Data = updatedTask
            });
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var success = await _service.DeleteAsync(id);

            if (!success)
                return NotFound("Tarea no encontrada");

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Tarea eliminada correctamente"
            });
        }
    }
}
