using AgendaMedica.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Persitence.Contexts.Configuration
{
    public class LaboratoryTestConfiguration : IEntityTypeConfiguration<LaboratoryTest>
    {
        public void Configure(EntityTypeBuilder<LaboratoryTest> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(20);

            builder.HasOne(x => x.ConsultingRoom)
                .WithMany(x => x.LaboratoryTests)
                .HasForeignKey(x => x.ConsultingRoomId)
                .OnDelete(DeleteBehavior.NoAction); // Cambiar a Restrict

            builder.HasMany(x => x.LaboryTestAppointments)
                .WithOne(x => x.LaboratoryTest)
                .HasForeignKey(x => x.LaboratoryTestId);

            builder.HasMany(x => x.LaboratoryResults)
                .WithOne(x => x.LaboratoryTest)
                .HasForeignKey(x => x.LaboratoryTestId)
                  .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
