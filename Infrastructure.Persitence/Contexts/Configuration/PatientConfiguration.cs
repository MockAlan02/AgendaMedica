using AgendaMedica.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persitence.Contexts.Configuration
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(20);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(40);
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(11);
            builder.Property(x => x.Direction).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Cedula).IsRequired().HasMaxLength(11);
            builder.Property(x => x.BirthDate).IsRequired();
            builder.Property(x => x.Smoke).IsRequired();
            builder.Property(x => x.Allergy).IsRequired();

            builder.HasOne(t => t.ConsultingRoom)
                .WithMany(t => t.Patients)
                .HasForeignKey(t => t.ConsultingRoomId)
                .OnDelete(DeleteBehavior.NoAction); // Cambiar a Restrict

            builder.HasMany(t => t.Appointments)
                .WithOne(t => t.Patient)
                .HasForeignKey(t => t.PatientId);

            builder.HasMany(t => t.LaboratoryResults)
                .WithOne(t => t.Patient)
                .HasForeignKey(t => t.PatientId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
