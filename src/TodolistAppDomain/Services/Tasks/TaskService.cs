using TodolistAppDomain.Interfaces;
using TodolistAppModels.Informations.Tasks;

namespace TodolistAppDomain.Services.Tasks
{
    public class TaskService : ITaskService
    {
        private readonly IListRepository _listRepository;
        private readonly ITaskRepository _taskRepository;

        public TaskService(IListRepository listRepository, ITaskRepository taskRepository)
        {
            _listRepository = listRepository;
            _taskRepository = taskRepository;
        }

        public async Task PrepareTaskToTransfer(TransferTaskInformation transferTaskInformation)
        {
            var lists = await _listRepository.GetLists(transferTaskInformation.BoardId);

            var task = await _taskRepository.GetTask(transferTaskInformation.TaskId);
            task.ListId = lists[transferTaskInformation.ListOrder].Id;
            await _taskRepository.Update(task);
        }

        public async Task ReOrderTasks(ReOrderTasksInformation reorderTasksInformation)
        {
            var tasks = await _taskRepository.GetTasks(reorderTasksInformation.Tasks[0].ListId);
            
            foreach (var task in tasks)
                task.Order = reorderTasksInformation.Tasks.FindIndex(x => x.Id == task.Id) + 1;

            await _taskRepository.UpdateTasks(tasks);
        }
    }
}
