using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodolistAppModels.Entities
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int Order { get; set; }

        [ForeignKey("List")]
        public int ListId { get; set; }
        public virtual List List { get; set; }
    }
}
