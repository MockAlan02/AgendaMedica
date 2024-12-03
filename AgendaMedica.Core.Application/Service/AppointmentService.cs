using AgendaMedica.Core.Application.Interface.Repository;
using AgendaMedica.Core.Application.Interface.Service;
using AgendaMedica.Core.Application.ViewModels.Appoiment;
using AgendaMedica.Core.Domain.Entities;


namespace AgendaMedica.Core.Application.Service
{
    public class AppointmentService : IGenericService<SaveAppointmentViewModel, AppointmentViewModel>, IAppointmentService
    {
        private readonly IAppointmentsRepository _repository;
        private readonly ILaboratoryResultService _resultService;
        public AppointmentService(IAppointmentsRepository repository , ILaboratoryResultService resultService)
        {
            _repository = repository;
            _resultService = resultService;
        }
        public async Task Add(SaveAppointmentViewModel vm)
        {
            Appointment appointment = new()
            {
                Id = vm.Id,
                DateAppointment = vm.DateAppointment,
                Description = vm.Description,
                DoctorId = vm.DoctorId,
                PatientId = vm.PatientId,
                StatusId = vm.StatusId,
                ConsultingRoomId = vm.ConsultingRoomId
            };
            await _repository.AddAsync(appointment);
        }

        public async Task Delete(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<AppointmentViewModel>> GetAllViewModel()
        {
            IEnumerable<Appointment> listAppointment = await _repository.GetAllAsync();
            return listAppointment.Select(x => new AppointmentViewModel
            {
                Id = x.Id,
                DateAppointment = x.DateAppointment,
                Description = x.Description,
                DoctorName = x.Doctor!.Name,
                PatientName = x.Patient!.Name,
                StatusId = x.StatusId,
                ConsultingRoomId = x.ConsultingRoomId
            }).ToList();
        }

        public async Task<SaveAppointmentViewModel> GetByIdSaveViewModel(int id)
        {

            Appointment appointment = await _repository.GetByIdAsync(id);

            return new SaveAppointmentViewModel

            {
                ConsultingRoomId = appointment.ConsultingRoomId,
                DateAppointment = appointment.DateAppointment,
                Description = appointment.Description,
                DoctorId = appointment.DoctorId,
                PatientId = appointment.PatientId,
                StatusId = appointment.StatusId,
                Id = appointment.Id

            };
        }

        public async Task Update(SaveAppointmentViewModel vm)
        {
            Appointment appointment = await _repository.GetByIdAsync(vm.Id);

            appointment.Id = vm.Id;
            appointment.DateAppointment = vm.DateAppointment;
            appointment.Description = vm.Description;
            appointment.DoctorId = vm.DoctorId;
            appointment.PatientId = vm.PatientId;
            if(vm.StatusId != 0)
            {
            appointment.StatusId = vm.StatusId;
            }
        

            await _repository.UpdateAsync(appointment);
        }
        public async Task<IEnumerable<AppointmentViewModel>> GetAppointmensByConsultingId(int id)
        {
            var appointments = await _repository.GetAppointmentsByConsultingId(id);

            return appointments.Select(x => new AppointmentViewModel
            {
                ConsultingRoomId = x.ConsultingRoomId,
                DateAppointment = x.DateAppointment,
                Description = x.Description,
                DoctorName = x.Doctor!.Name,
                Id = x.Id,
                PatientName = x.Patient!.Name,
                StatusId = x.StatusId,
            }).ToList() ?? Enumerable.Empty<AppointmentViewModel>();
        }
        public async Task DeleteAppointmentByPatientId(int id)
        {
            var appointments = await _repository.GetAllAsync();
            var appointmentPatients = appointments.Where(x => x.PatientId == id).ToList();
            foreach( var appointmentPatient in appointmentPatients)
            {
                await _resultService.DeleteResultsByAppointmentId(appointmentPatient.Id);
                await _repository.DeleteAsync(appointmentPatient.Id);
            }
        }

        public async Task DeleteAppointmentByDoctorId(int id)
        {
            var appointments = await _repository.GetAllAsync();
            var appointmentPatients = appointments.Where(x => x.DoctorId == id).ToList();
            foreach (var appointmentPatient in appointmentPatients)
            {
                await _resultService.DeleteResultsByAppointmentId(appointmentPatient.Id);
                await _repository.DeleteAsync(appointmentPatient.Id);
            }
        }
    }
}
