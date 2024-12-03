using AgendaMedica.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persitence.Contexts.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
          
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(20);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(40);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(70);

            builder.Property(x => x.Username).IsRequired().HasMaxLength(30);
            //Unique Constraint
            builder.HasIndex(x => x.Username).IsUnique();
            
            builder.Property(x => x.Password).IsRequired().HasMaxLength(250);
            builder.HasOne(x => x.ConsultingRoom).WithMany(x => x.Users).HasForeignKey(x => x.ConsultingRoomId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Role).WithMany(x => x.Users).HasForeignKey(x => x.RoleId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
