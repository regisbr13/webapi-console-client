using System;
using Access.Models;

namespace Webapi.Models {
    public class Scheduling : BaseEntity {
        public string Comand { get; set; }
        public string Response { get; set; }
        public DateTime ExecutionDate { get; set; }
        public DateTime SchedulingDate { get; set; }
        public int ComputerId { get; set; }
        public Computer Computer { get; set; }
    }
}