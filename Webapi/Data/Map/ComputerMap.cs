using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Webapi.Models;

namespace Webapi.Data.Map {
    public class ComputerMap : IEntityTypeConfiguration<Computer> {
        public void Configure (EntityTypeBuilder<Computer> builder) {
            builder.HasKey (x => x.Id);
            builder.HasOne (x => x.User).WithMany (x => x.Computers).HasForeignKey (x => x.UserId);
            builder.HasMany (x => x.Schedulings).WithOne (x => x.Computer).HasForeignKey (x => x.ComputerId);
        }
    }
}