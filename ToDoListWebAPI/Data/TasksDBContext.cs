using Microsoft.EntityFrameworkCore;
using ToDoListWebAPI.Data.Map;
using ToDoListWebAPI.Models;

namespace ToDoListWebAPI.Data
{
    public class TasksDBContext : DbContext
    {
        public TasksDBContext(DbContextOptions<TasksDBContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TaskMap());
            base.OnModelCreating(modelBuilder);
        }





    }
}
