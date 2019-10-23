using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Webapi.Models;

namespace Webapi.Data.Map {
    public class UserMap : IEntityTypeConfiguration<User> {
        public void Configure (EntityTypeBuilder<User> builder) {
            builder.HasKey (x => x.Id);
            builder.HasMany (x => x.Computers).WithOne (x => x.User).HasForeignKey (x => x.UserId);
        }
    }
}