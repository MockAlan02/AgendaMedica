

using AgendaMedica.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persitence.Contexts.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
           builder.HasKey(x => x.Id);
           builder.Property(x => x.Name).IsRequired().HasMaxLength(20);
           builder.Property(x => x.Description).IsRequired().HasMaxLength(60);

            builder.HasMany(t => t.Users).WithOne(t => t.Role).HasForeignKey(x => x.RoleId);
        }
    }
}
