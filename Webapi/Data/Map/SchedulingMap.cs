using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Webapi.Models;

namespace Webapi.Data.Map
{
    public class SchedulingMap : IEntityTypeConfiguration<Scheduling>
    {
        public void Configure(EntityTypeBuilder<Scheduling> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Computer).WithMany(x => x.Schedulings).HasForeignKey(x => x.ComputerId);
        }
    }

}