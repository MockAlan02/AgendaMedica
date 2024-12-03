using AgendaMedica.Core.Domain.Entities;

namespace AgendaMedica.Core.Application.Interface.Repository
{
    public interface IDoctorRepository : IGenericRepository<Doctor>
    {
        Task<IEnumerable<Doctor>> GetDoctorsByConsultingRoomIdAsync(int id);
    }
}