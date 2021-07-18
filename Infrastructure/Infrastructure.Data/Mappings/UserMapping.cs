using Domain.Aggregates.UserAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.ExternalId).IsRequired().HasMaxLength(21).HasColumnType("varchar");
            builder.Property(x => x.Name).IsRequired().HasMaxLength(40).HasColumnType("varchar");
            builder.Property(x => x.Birthday).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.UpdatedAt).IsRequired();
            builder.Property(x => x.Username).IsRequired().HasMaxLength(20).HasColumnType("varchar");
            builder.Property(x => x.CryptedPassword).IsRequired().HasMaxLength(50).HasColumnType("varchar");
            builder.Property(x => x.Active).IsRequired();
            builder.Property(x => x.Roles).IsRequired().HasMaxLength(20).HasColumnType("varchar");
        }
    }
}