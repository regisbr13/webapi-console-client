namespace Webapi.Data.VO 
{
    public class ComputerVO 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ip { get; set; }
        public string OS { get; set; }
        public string Username { get; set; }
        public string DiskSpace { get; set; }
        public string MemoryInfo { get; set; }
        public int UserId { get; set; }
    }
}