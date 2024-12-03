

using AgendaMedica.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persitence.Contexts.Configuration
{
    public class ConsultingRoomConfiguration : IEntityTypeConfiguration<ConsultingRoom>
    {
        public void Configure(EntityTypeBuilder<ConsultingRoom> builder)
        {
           builder.HasKey(t  => t.Id);
           builder.Property(t => t.Name).IsRequired().HasMaxLength(20);
           builder.HasMany(t => t.Doctors).WithOne(t => t.ConsultingRoom).HasForeignKey(t => t.ConsultingRoomId).OnDelete(DeleteBehavior.Cascade);
           builder.HasMany(t => t.Users).WithOne(t => t.ConsultingRoom).HasForeignKey(t => t.ConsultingRoomId).OnDelete(DeleteBehavior.Cascade);
           builder.HasMany(t => t.Patients).WithOne(t => t.ConsultingRoom).HasForeignKey(t => t.ConsultingRoomId).OnDelete(DeleteBehavior.Cascade);
           builder.HasMany(t => t.LaboratoryTests).WithOne(t => t.ConsultingRoom).HasForeignKey(t => t.ConsultingRoomId).OnDelete(DeleteBehavior.Cascade);
           builder.HasMany(t => t.Appointments).WithOne(t => t.ConsultingRoom).HasForeignKey(t => t.ConsultingRoomId).OnDelete(DeleteBehavior.Cascade);
           builder.HasMany(t => t.LaboratoryResult).WithOne(t => t.ConsultingRoomName).HasForeignKey(t => t.ConsultingRoomId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
