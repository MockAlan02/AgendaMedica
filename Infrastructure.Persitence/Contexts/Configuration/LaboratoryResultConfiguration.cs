using AgendaMedica.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Persitence.Contexts.Configuration
{
    internal class LaboratoryResultConfiguration : IEntityTypeConfiguration<LaboratoryResult>
    {
        public void Configure(EntityTypeBuilder<LaboratoryResult> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Result).HasMaxLength(240);

            builder.HasOne(lr => lr.Patient)
                .WithMany(p => p.LaboratoryResults)
                .HasForeignKey(lr => lr.PatientId)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(lr => lr.LaboratoryTest)
                .WithMany(lt => lt.LaboratoryResults)
                .HasForeignKey(lr => lr.LaboratoryTestId)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(lr => lr.ConsultingRoomName)
                .WithMany(lt => lt.LaboratoryResult)
                .HasForeignKey(lt =>  lt.ConsultingRoomId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(t => t.Appointment).WithMany(t => t.LaboratoryResult).HasForeignKey(t => t.AppointmentId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
