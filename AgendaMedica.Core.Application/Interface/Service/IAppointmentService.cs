using AgendaMedica.Core.Application.ViewModels.Appoiment;
using System.Threading.Tasks;

namespace AgendaMedica.Core.Application.Interface.Service
{
    public interface IAppointmentService : IGenericService<SaveAppointmentViewModel, AppointmentViewModel>
    {
        Task<IEnumerable<AppointmentViewModel>> GetAppointmensByConsultingId(int id);
        Task DeleteAppointmentByPatientId(int id);
        Task DeleteAppointmentByDoctorId(int id);
  }
}