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

            //var task = new TodolistAppModels.Entities.Task();
            //task.ListId = lists[transferTaskInformation.ListOrder].Id;
            //await _taskRepository.Update(task);
        }
    }
}
