using AgendaMedica.Core.Application.ViewModels.LaboratoryResult;

namespace AgendaMedica.Core.Application.Interface.Service
{
    public interface ILaboratoryResultService : IGenericService<SaveLaboratoryResultViewModel, LaboratoryResultViewModel>
    {
        Task<IEnumerable<LaboratoryResultViewModel>> GetTestByConsultingRoomId(int id);
        Task DeleteResultsByAppointmentId(int id);
        Task<IEnumerable<LaboratoryResultViewModel>> GetResultsByCedulaAsync(int consultingId, string cedula);
        Task DeleteResultsByLaboratoryTestId(int id);
    }
}