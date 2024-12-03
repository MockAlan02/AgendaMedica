using AgendaMedica.Core.Domain.Entities;

namespace AgendaMedica.Core.Application.Interface.Repository
{
    public interface ILaboratorytestRepository : IGenericRepository<LaboratoryTest>
    {
        Task<IEnumerable<LaboratoryTest>> GetTestsByConsultingRoomId(int id);
    }
}