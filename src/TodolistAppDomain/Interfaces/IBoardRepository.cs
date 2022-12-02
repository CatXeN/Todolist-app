using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodolistAppModels.Entities;
using TodolistAppModels.Informations.Boards;

namespace TodolistAppDomain.Interfaces
{
    public interface IBoardRepository 
    {
        Task<Board> Insert(Board entity);
        Task<IEnumerable<Board>> GetAll(int userId);
        Task<Board> GetBoard(int id);
        System.Threading.Tasks.Task AssignUserToBoard(UserToBoard assign);
        Task<List<AssignedUserToBoard>> GetAssignedUserToBoard(int boardId);
    }
}
