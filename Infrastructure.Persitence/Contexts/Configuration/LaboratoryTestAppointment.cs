using AgendaMedica.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Persitence.Contexts.Configuration
{
    public class LaboratoryTestAppointment : IEntityTypeConfiguration<LaboryTestAppointment>
    {
        public void Configure(EntityTypeBuilder<LaboryTestAppointment> builder)
        {
            builder.HasKey(bp => bp.Id);
            builder.Property(x => x.LaboratoryTestId).IsRequired();
            builder.Property(x => x.AppoinmentId).IsRequired();
            builder.HasOne(t => t.Appointment).WithMany(t => t.LaboryTestAppointments).HasForeignKey(x => x.AppoinmentId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.LaboratoryTest).WithMany(t => t.LaboryTestAppointments).HasForeignKey(x => x.LaboratoryTestId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
