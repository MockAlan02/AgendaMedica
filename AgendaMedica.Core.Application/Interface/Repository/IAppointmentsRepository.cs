using AgendaMedica.Core.Domain.Entities;

namespace AgendaMedica.Core.Application.Interface.Repository
{
    public interface IAppointmentsRepository : IGenericRepository<Appointment>
    {
        Task<IEnumerable<Appointment>> GetAppointmentsByConsultingId(int id);
    }
}