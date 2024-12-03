using AgendaMedica.Core.Application.ViewModels.Doctor;

namespace AgendaMedica.Core.Application.Interface.Service
{
    public interface IDoctorService : IGenericService<SaveDoctorViewModel, DoctorViewModel>
    {
        Task<IEnumerable<DoctorViewModel>> GetDoctorsByConsultingRoomId(int id);
        Task<SaveDoctorViewModel> AddAsync(SaveDoctorViewModel vm);
    }
}