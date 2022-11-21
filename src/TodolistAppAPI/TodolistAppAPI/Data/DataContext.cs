using Microsoft.EntityFrameworkCore;

namespace TodolistAppAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<TodolistAppModels.Entities.Task> Tasks { get; set; }   
    }
}
