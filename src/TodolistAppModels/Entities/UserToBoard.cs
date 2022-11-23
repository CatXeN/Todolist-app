using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodolistAppModels.Entities
{
    public class UserToBoard
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Board")]
        public int BoardId { get; set; }
        public bool IsOwner { get; set; }

        public virtual User User { get; set; }
        public virtual Board Board { get; set; }
    }
}
