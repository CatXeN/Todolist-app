using Microsoft.EntityFrameworkCore;
using TodolistAppModels.Entities;
using Task = TodolistAppModels.Entities.Task;

namespace TodolistAppAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<List> Lists { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserToBoard> UsersToBoards { get; set; }
    }
}
