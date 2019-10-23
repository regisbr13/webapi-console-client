using Microsoft.EntityFrameworkCore;
using Webapi.Data.Map;
using Webapi.Models;

namespace Webapi.Data {
    public class Context : DbContext {
        public Context (DbContextOptions<Context> options) : base (options) { }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Scheduling> Schedulings { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration (new ComputerMap ());
            modelBuilder.ApplyConfiguration (new UserMap ());
            modelBuilder.ApplyConfiguration (new SchedulingMap ());
        }
    }
}