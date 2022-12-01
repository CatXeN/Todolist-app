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
        var order = _context.Tasks.Where(t => t.ListId == task.ListId);
        task.Order = !order.Any() ? 1 : await order.MaxAsync(x => x.Order) + 1;

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

    public async System.Threading.Tasks.Task UpdateTasks(List<Task> tasks)
    {
        _context.Tasks.UpdateRange(tasks);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Task>> GetTasks(int listId)
    {
        return await _context.Tasks.Where(x => x.ListId == listId).ToListAsync();
    }
}