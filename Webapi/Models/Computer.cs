using System.Collections.Generic;
using Access.Models;

namespace Webapi.Models
{
    public class Computer : BaseEntity
    {
        public string Name { get; set; }
        public string Ip { get; set; }
        public string OS { get; set; }
        public string Username { get; set; }
        public string DiskSpace { get; set; }
        public string MemoryInfo { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Scheduling> Schedulings { get; set; }
    }
}