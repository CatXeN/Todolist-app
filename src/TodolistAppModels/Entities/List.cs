using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodolistAppModels.Entities
{
    public class List
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }

        [ForeignKey("Board")]
        public int BoardId { get; set; }
        public virtual Board Board { get; set; }
    }
}
