using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodolistAppAPI.Data;
using TodolistAppDomain.Interfaces;
using TodolistAppModels.Entities;

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

        public async Task<IEnumerable<Board>> GetAll()
        {
            return await _context.Boards.ToListAsync();
        }

        public async Task<Board> GetBoard(int id)
        {
            return await _context.Boards.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
