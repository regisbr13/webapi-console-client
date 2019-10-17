using System;

namespace Agent.Models
{
    public class Scheduling
    {
        public int Id { get; set; }
        public string Comand { get; set; }
        public string Response { get; set; }
        public DateTime ExecutionDate { get; set; }
        public DateTime SchedulingDate { get; set; }
        public int ComputerId { get; set; }
    }
}
