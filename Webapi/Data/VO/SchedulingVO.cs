using System;
using System.ComponentModel.DataAnnotations;

namespace Webapi.Data.VO 
{
    public class SchedulingVO 
    {
        public int Id { get; set; }

        [Required]
        public string Comand { get; set; }
        public string Response { get; set; }
        public DateTime ExecutionDate { get; set; }
        public DateTime SchedulingDate { get; set; }
        public int ComputerId { get; set; }
    }
}