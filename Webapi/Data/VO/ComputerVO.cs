using System.Collections.Generic;
using Tapioca.HATEOAS;

namespace Webapi.Data.VO 
{
    public class ComputerVO : ISupportsHyperMedia
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ip { get; set; }
        public string OS { get; set; }
        public string Username { get; set; }
        public string DiskSpace { get; set; }
        public string MemoryInfo { get; set; }
        public int UserId { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}