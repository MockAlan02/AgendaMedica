using AgendaMedica.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;


namespace Infrastructure.Persitence.Contexts.Configuration
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
      
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Description).IsRequired().HasMaxLength(250);
            builder.Property(t => t.DateAppointment).IsRequired();
            builder.Property(t => t.PatientId).IsRequired();


            builder.HasOne(t => t.Patient).WithMany(t => t.Appointments).HasForeignKey(t => t.PatientId).OnDelete(DeleteBehavior.Restrict); ;
            builder.HasOne(t => t.Status).WithMany(t => t.Appointments).HasForeignKey(t => t.StatusId);

            builder.HasOne(t => t.Doctor).WithMany(t => t.Appointments).HasForeignKey(t => t.DoctorId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.ConsultingRoom).WithMany(t => t.Appointments).HasForeignKey(t => t.ConsultingRoomId);
            builder.HasMany(t => t.LaboryTestAppointments).WithOne(t => t.Appointment).HasForeignKey(t => t.AppoinmentId);
            builder.HasMany(t => t.LaboratoryResult).WithOne(t => t.Appointment).HasForeignKey(t => t.AppointmentId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
