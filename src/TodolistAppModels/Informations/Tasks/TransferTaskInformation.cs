using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodolistAppModels.Informations.Tasks
{
    public class TransferTaskInformation
    {
        public int TaskId { get; set; }
        public int ListOrder { get; set; }
        public int BoardId { get; set; }
    }
}
