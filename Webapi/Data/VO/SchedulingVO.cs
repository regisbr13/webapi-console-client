using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tapioca.HATEOAS;

namespace Webapi.Data.VO 
{
    public class SchedulingVO : ISupportsHyperMedia
    {
        public int Id { get; set; }

        [Required]
        public string Comand { get; set; }
        public string Response { get; set; }
        public DateTime ExecutionDate { get; set; }
        public DateTime SchedulingDate { get; set; }
        public int ComputerId { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}