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

    public async System.Threading.Tasks.Task Update(Task task)
    {
        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();
    }
    
    public async Task<Task> GetTask(int taskId)
    {
        return await _context.Tasks.FirstOrDefaultAsync(x => x.Id == taskId);
    }
}