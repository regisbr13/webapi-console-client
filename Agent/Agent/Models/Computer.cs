using System.Collections.Generic;

namespace Agent.Models {
    public class Computer {
        public int Id { get; set; }
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