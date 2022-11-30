using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodolistAppModels.Informations
{
    public class ListInformation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }

        public IEnumerable<Entities.Task> Tasks { get; set; }
    }
}
