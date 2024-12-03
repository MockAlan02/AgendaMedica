using AgendaMedica.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Persitence.Contexts.Configuration
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(20);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(40);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(70);
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(11);
            builder.Property(x => x.Cedula).IsRequired().HasMaxLength(11);
            builder.HasOne(t => t.ConsultingRoom).WithMany(t => t.Doctors).HasForeignKey(t => t.ConsultingRoomId);
            builder.HasMany(t => t.Appointments).WithOne(t => t.Doctor).HasForeignKey(t => t.DoctorId);
        }
    }
}
