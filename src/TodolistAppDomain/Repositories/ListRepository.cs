using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodolistAppAPI.Data;
using TodolistAppDomain.Helper;
using TodolistAppDomain.Interfaces;
using TodolistAppModels.Entities;

namespace TodolistAppDomain.Repositories
{
    public class ListRepository : IListRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        
        public ListRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<List>> GetFullList(int boardId)
        {
            return _mapper.Map<IEnumerable<List>>(await _context.Lists.
                Where(l => l.BoardId == boardId).
                Include(t => t.Tasks).
                ToListAsync());
        }

        public async System.Threading.Tasks.Task InsertDefaultList(int boardId)
        {
            var list = ListHelper.GenerateDefaultLists(boardId);
            await _context.Lists.AddRangeAsync(list);
            await _context.SaveChangesAsync();
        }
    }
}
