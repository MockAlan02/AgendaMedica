using AgendaMedica.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persitence.Contexts
{
    public class ScheduleAppointmentContext : DbContext
    {
       
        public ScheduleAppointmentContext(DbContextOptions<ScheduleAppointmentContext> option) : base(option) { }
        
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet <ConsultingRoom> ConsultingRooms { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<LaboratoryTest> LaboratoryTest { get; set;}
        public DbSet<LaboryTestAppointment> LaboryTestAppointment { get; set;}
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<LaboratoryResult> LaboratoryResults { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }

}
