using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodolistAppModels.Entities;

namespace TodolistAppDomain.Interfaces
{
    public interface IBoardRepository 
    {
        Task<Board> Insert(Board entity);
        Task<IEnumerable<Board>> GetAll();
    }
}
