using Microsoft.AspNetCore.Mvc;
using TodolistAppDomain.Interfaces;
using TodolistAppDomain.Services.Tasks;
using TodolistAppModels.Informations;
using TodolistAppModels.Informations.Tasks;
using Task = TodolistAppModels.Entities.Task;

namespace TodolistAppAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TaskController: ControllerBase
{
    private readonly ITaskRepository _repository;
    private readonly ITaskService _service;

    public TaskController(ITaskRepository repository, ITaskService service)
    {
        _repository = repository;
        _service = service;
    }
    
    [HttpPost]
    public async Task<IActionResult> InsertTask(AddTaskInformation addTaskInformation)
    {
        var task = new TodolistAppModels.Entities.Task()
        {
            Name = addTaskInformation.Name,
            Description = addTaskInformation.Description,
            Date = DateTime.Now,
            ListId = addTaskInformation.ListId
        };

        await _repository.Insert(task);
        return Ok();
    }

    [HttpPost("transferTask")]
    public async Task<IActionResult> TransferTask(TransferTaskInformation taskInformation)
    {
        await _service.PrepareTaskToTransfer(taskInformation);
        return Ok(true);
    }

    [HttpPost("reOrder")]
    public async Task<IActionResult> ReOrderTasks(ReOrderTasksInformation tasks)
    {
        await _service.ReOrderTasks(tasks);
        return Ok(true);
    }

    [HttpGet]
    public async Task<IActionResult> GetTask(int id)
    {
        var task = await _repository.GetTask(id);
        return Ok(task);
    }
}