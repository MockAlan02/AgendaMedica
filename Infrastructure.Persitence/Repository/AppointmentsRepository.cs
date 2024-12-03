using AgendaMedica.Core.Application.Interface.Repository;
using AgendaMedica.Core.Domain.Entities;
using Infrastructure.Persitence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persitence.Repository
{
    internal class AppointmentsRepository : GenericRepository<Appointment>, IAppointmentsRepository
    {
        private readonly DbSet<Appointment> _appointments;
        public AppointmentsRepository(ScheduleAppointmentContext context) : base(context)
        {
            _appointments = context.Set<Appointment>();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByConsultingId(int id)
        {
            var appointments = await _appointments.Where(x => x.ConsultingRoomId == id)
                .Include(x => x.Patient).Include(x => x.Doctor).ToListAsync();
            return appointments;
        }
    }
}
