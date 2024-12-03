using AgendaMedica.Core.Application.Interface.Repository;
using AgendaMedica.Core.Domain.Entities;
using Infrastructure.Persitence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persitence.Repository
{
    public class LaboratorytestRepository : GenericRepository<LaboratoryTest>, ILaboratorytestRepository
    {
        private readonly DbSet<LaboratoryTest> _laboratoryTests;

        public LaboratorytestRepository(ScheduleAppointmentContext context) : base(context)
        {
            _laboratoryTests = context.Set<LaboratoryTest>();
        }

        public async Task<IEnumerable<LaboratoryTest>> GetTestsByConsultingRoomId(int id)
        {
            return await _laboratoryTests.Where(x => x.ConsultingRoomId == id).ToListAsync();
        }


    }
}
