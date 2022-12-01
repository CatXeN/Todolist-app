using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodolistAppAPI.Data;
using TodolistAppDomain.Helper;
using TodolistAppDomain.Interfaces;
using TodolistAppModels.Entities;
using TodolistAppModels.Informations;

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

        public async Task<List<List>> GetLists(int boardId) => await _context.Lists.Where(l => l.BoardId == boardId).ToListAsync();

        public async Task<List<ListInformation>> GetFullList(int boardId)
        {
            var list =  _mapper.Map<IEnumerable<List>>(await _context.Lists.
                Where(l => l.BoardId == boardId).
                ToListAsync());

            var lists = list.Select(l => new ListInformation()
            {
                Id = l.Id,
                Name = l.Name,
                Order = l.Order,
                Tasks = _context.Tasks.Where(t => t.ListId == l.Id).ToList()
            }).ToList();

            return lists;
        }

        public async System.Threading.Tasks.Task InsertDefaultList(int boardId)
        {
            var list = ListHelper.GenerateDefaultLists(boardId);
            await _context.Lists.AddRangeAsync(list);
            await _context.SaveChangesAsync();
        }
    }
}
