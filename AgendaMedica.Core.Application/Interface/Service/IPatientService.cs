using AgendaMedica.Core.Application.ViewModels.Patient;
using AgendaMedica.Core.Domain.Entities;

namespace AgendaMedica.Core.Application.Interface.Service
{
    public interface IPatientService : IGenericService<SavePatienViewModel, PatientViewModel>
    {
        Task<IEnumerable<PatientViewModel>> GetPatientsByConsultingId(int id);
        Task<SavePatienViewModel> AddAsync(SavePatienViewModel vm);
    }
}