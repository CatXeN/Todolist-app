using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodolistAppAPI.Data;
using TodolistAppDomain.Interfaces;
using TodolistAppModels.Entities;
using TodolistAppModels.Informations.Boards;

namespace TodolistAppDomain.Repositories
{
    public class BoardRepository : IBoardRepository
    {
        private readonly DataContext _context;

        public BoardRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Board> Insert(Board entity)
        {
           await _context.Boards.AddAsync(entity);
           await _context.SaveChangesAsync();
           return entity;
        }

        public async Task<IEnumerable<Board>> GetAll(int userId)
        {
            var usersToBoard = await _context.UsersToBoards.
                Where(x => x.UserId == userId).
                Select(b => b.BoardId).
                ToListAsync();

            return await _context.Boards.Where(x => usersToBoard.Contains(x.Id)).ToListAsync();
        }

        public async Task<Board> GetBoard(int id)
        {
            return await _context.Boards.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async System.Threading.Tasks.Task AssignUserToBoard(UserToBoard assign)
        {
            await _context.AddAsync(assign);
            await _context.SaveChangesAsync();
        }

        public async Task<List<AssignedUserToBoard>> GetAssignedUserToBoard(int boardId)
        {
            var users = await _context.UsersToBoards.
                Include(x => x.User).
                Where(x => x.BoardId == boardId).Select(x => new AssignedUserToBoard()
                {
                    Id = x.UserId,
                    Email = x.User.Email,
                }).ToListAsync();

            return users;
        }
    }
}
