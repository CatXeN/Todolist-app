using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodolistAppAPI.Data;
using TodolistAppDomain.Interfaces;
using Task = TodolistAppModels.Entities.Task;

namespace TodolistAppDomain.Repositories;

public class TaskRepository: ITaskRepository
{
    private readonly DataContext _context;
    
    public TaskRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<Task> Insert(Task task)
    {
        await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async IActionResult GetTask(int taskId)
    {
        return 
    }
}