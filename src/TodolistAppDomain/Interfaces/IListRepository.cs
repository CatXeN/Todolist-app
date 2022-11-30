using TodolistAppModels.Entities;
using TodolistAppModels.Informations;

namespace TodolistAppDomain.Interfaces
{
    public interface IListRepository
    {
        System.Threading.Tasks.Task InsertDefaultList(int boardId);
        Task<List<ListInformation>> GetFullList(int boardId);
        Task<List<List>> GetLists(int boardId);
    }
}
