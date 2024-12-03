

using AgendaMedica.Core.Application.Interface.Repository;
using AgendaMedica.Core.Domain.Entities;
using Infrastructure.Persitence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persitence.Repository
{
    public class LaboratoryResultRepository : GenericRepository<LaboratoryResult>, ILaboratoryResultRepository
    {
        private readonly DbSet<LaboratoryResult> _laboratoryResult;

        public LaboratoryResultRepository(ScheduleAppointmentContext context) : base(context)
        {
            _laboratoryResult = context.Set<LaboratoryResult>();
        }

        public async Task<IEnumerable<LaboratoryResult>> GetResultsLaboratoryByConsultingRoom(int id)
        {
            var result = await _laboratoryResult
        .Where(x => x.ConsultingRoomId == id).Include(x => x.Patient).Include(x => x.LaboratoryTest).ToListAsync();

            return result;
        }

      
    }
}
