using TodolistAppModels.Entities;

namespace TodolistAppDomain.Interfaces
{
    public interface IListRepository
    {
        System.Threading.Tasks.Task InsertDefaultList(int boardId);
        System.Threading.Tasks.Task<IEnumerable<List>> GetFullList(int boardId);
    }
}
