using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Models.Entities;

namespace TaskManagerAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<TaskItem> Tasks => Set<TaskItem>();
        public DbSet<UserEntity> User => Set<UserEntity>();
    }
}
