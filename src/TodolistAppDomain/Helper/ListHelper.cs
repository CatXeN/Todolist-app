using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodolistAppDomain.Helper
{
    public static class ListHelper
    {
        public static List<TodolistAppModels.Entities.List> GenerateDefaultLists(int boardId)
        {
            var list = new List<TodolistAppModels.Entities.List>
            {
                new TodolistAppModels.Entities.List()
                {
                    BoardId = boardId,
                    Name = "To Do",
                    Order = 1
                },
                new TodolistAppModels.Entities.List()
                {
                    BoardId = boardId,
                    Name = "In Progress",
                    Order = 2
                },
                new TodolistAppModels.Entities.List()
                {
                    BoardId = boardId,
                    Name = "Done",
                    Order = 3
                }
            };

            return list;
        }
    }
}
