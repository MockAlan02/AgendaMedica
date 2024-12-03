using AgendaMedica.Core.Application.Interface.Repository;
using AgendaMedica.Core.Domain.Entities;
using Infrastructure.Persitence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persitence.Repository
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        private readonly DbSet<Doctor> _doctor;
        public DoctorRepository(ScheduleAppointmentContext context) : base(context)
        {
            _doctor = context.Set<Doctor>();
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsByConsultingRoomIdAsync(int id)
        {
            return await _doctor.Where(x => x.ConsultingRoomId == id).ToListAsync()!;
        }
    }
}
