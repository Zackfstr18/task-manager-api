using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Services
{
    public class TaskService
    {
        #region Definitions
        private static readonly List<TaskItem> tasks = new();
        #endregion

        public List<TaskItem> GetAll() => tasks;

        public TaskItem? GetByID(int id) => tasks.FirstOrDefault(t => t.Id == id);

        public TaskItem Create(TaskItem task)
        {
            task.Id = tasks.Count + 1;
            task.IsCompleted = false;
            tasks.Add(task);
            return task;

        }      

        public bool CompleteTask(int id)
        {
            var task = GetByID(id);
            if(task == null)
            {
                return false;
            }

            task.IsCompleted = true;
            return true;
        }

        public bool DeleteTask(int id)
        {
            var task = GetByID(id);
            if (task == null)
            {
                return false;
            }
            tasks.Remove(task);
            return true;
            
        }
    }
}
