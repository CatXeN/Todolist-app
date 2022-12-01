using TodolistAppModels.Informations.Tasks;

namespace TodolistAppDomain.Services.Tasks
{
    public interface ITaskService
    {
        Task PrepareTaskToTransfer(TransferTaskInformation transferTaskInformation);
        Task ReOrderTasks(ReOrderTasksInformation reorderTasksInformation);
    }
}
