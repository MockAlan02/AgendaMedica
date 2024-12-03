using AgendaMedica.Core.Domain.Entities;

namespace AgendaMedica.Core.Application.Interface.Repository
{
    public interface ILaboratoryResultRepository : IGenericRepository<LaboratoryResult>
    {
        Task<IEnumerable<LaboratoryResult>> GetResultsLaboratoryByConsultingRoom(int id);
    }
}