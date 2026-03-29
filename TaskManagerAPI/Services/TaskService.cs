using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;
using TaskManagerAPI.Models.DTOs;
using TaskManagerAPI.Models.Entities;

namespace TaskManagerAPI.Services
{
    public class TaskService
    {
        #region Definitions
        private readonly AppDbContext _context;
        #endregion

        public TaskService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<(List<TaskItem> Items, int TotalCount)> GetAllAsync(PaginationParams pagination, int userId)
        {

            var query = _context.Tasks.Where(t => t.UserId == userId).AsQueryable();

            if (pagination.IsCompleted.HasValue)
            {
                query = query.Where(t => t.IsCompleted == pagination.IsCompleted.Value);
            }

            if (!string.IsNullOrWhiteSpace(pagination.Search))
            {
                query = query.Where(t => t.Title.Contains(pagination.Search));
            }

            if (!string.IsNullOrWhiteSpace(pagination.SortBy))
            {
                query = pagination.SortBy.ToLower() switch
                {
                    "title" => pagination.Descending
                        ? query.OrderByDescending(t => t.Title)
                        : query.OrderBy(t => t.Title),

                    "createdat" => pagination.Descending
                        ? query.OrderByDescending(t => t.CreatedAt)
                        : query.OrderBy(t => t.CreatedAt),

                    "status" => pagination.Descending
                        ? query.OrderByDescending(t => t.IsCompleted)
                        : query.OrderBy(t => t.IsCompleted),

                    _ => query.OrderBy(t => t.Id)
                };
            }
            else
            {
                query = query.OrderBy(t => t.Id);
            }

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((pagination.Page - 1)* pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            return (items, totalCount);
            
        }

        public async Task<TaskItem?> GetByIdAsync(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<TaskItem> CreateAsync(TaskItem task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<bool> CompleteAsync(int id)
        {
            var task = await GetByIdAsync(id);
            if (task == null) return false;

            task.IsCompleted = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var task = await GetByIdAsync(id);
            if (task == null) return false;

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
