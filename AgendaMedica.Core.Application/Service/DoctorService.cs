
using AgendaMedica.Core.Application.Interface.Repository;
using AgendaMedica.Core.Application.Interface.Service;
using AgendaMedica.Core.Application.ViewModels.Doctor;
using AgendaMedica.Core.Domain.Entities;

namespace AgendaMedica.Core.Application.Service
{
    public class DoctorService : IGenericService<SaveDoctorViewModel, DoctorViewModel>, IDoctorService
    {
        private readonly IDoctorRepository _repository;
        private readonly IAppointmentService _appointmentService;

        public DoctorService(IDoctorRepository repository, IAppointmentService appointmentService)
        {
            _repository = repository;
            _appointmentService = appointmentService;
        }
        public async Task Add(SaveDoctorViewModel vm)
        {
            Doctor doctor = new()
            {
                ConsultingRoomId = vm.ConsultingRoomId,
                LastName = vm.LastName,
                Cedula = vm.Cedula,
                Name = vm.Name,
                PhoneNumber = vm.PhoneNumber,
                Picture = vm.Picture,

            };
            await _repository.AddAsync(doctor);
        }

        public async Task<SaveDoctorViewModel> AddAsync(SaveDoctorViewModel vm)
        {
            Doctor doctor = new()
            {
                ConsultingRoomId = vm.ConsultingRoomId,
                LastName = vm.LastName,
                Email = vm.Email,
                Cedula = vm.Cedula,
                Name = vm.Name,
                PhoneNumber = vm.PhoneNumber,
                Picture = vm.Picture,

            };
            await _repository.AddAsync(doctor);
            return new SaveDoctorViewModel
            {
                Id = doctor.Id,
                Name = doctor.Name,
                PhoneNumber = doctor.PhoneNumber,
                Cedula = doctor.Cedula,
                ConsultingRoomId = doctor.ConsultingRoomId,
                LastName = doctor.LastName,
                Email = doctor.Email
            };
        }

        public async Task Delete(int id)
        {
            await _appointmentService.DeleteAppointmentByDoctorId(id);
            await _repository.DeleteAsync(id);
        }

        public async Task<List<DoctorViewModel>> GetAllViewModel()
        {
            IEnumerable<Doctor> doctors = await _repository.GetAllAsync();
            return doctors.Select(x => new DoctorViewModel
            {
                Picture = x.Picture,
                Cedula = x.Cedula,
                Name = x.Name,
                PhoneNumber = x.PhoneNumber,
                ConsultingRoomId = x.ConsultingRoomId,
                LastName = x.LastName,
                Email = x.Email,
                Id = x.Id,
            }).ToList();
        }

        public async Task<SaveDoctorViewModel> GetByIdSaveViewModel(int id)
        {
            Doctor doctor = await _repository.GetByIdAsync(id);
            return new SaveDoctorViewModel
            {
                Id = doctor.Id,
                Picture = doctor.Picture,
                Cedula = doctor.Cedula,
                Name = doctor.Name,
                PhoneNumber = doctor.PhoneNumber,
                ConsultingRoomId = doctor.ConsultingRoomId,
                LastName = doctor.LastName,
                Email = doctor.Email
            };
        }

        public async Task Update(SaveDoctorViewModel vm)
        {
            Doctor doctor = await _repository.GetByIdAsync(vm.Id);
            doctor.Id = vm.Id;
            doctor.ConsultingRoomId = vm.ConsultingRoomId;
            doctor.LastName = vm.LastName;
            doctor.Cedula = vm.Cedula;
            doctor.Name = vm.Name;
            doctor.PhoneNumber = vm.PhoneNumber;

            //Confirm the picture update with null data
            if (vm.FormFile != null || vm.Picture != "")
            {
                doctor.Picture = vm.Picture;
            }


            await _repository.UpdateAsync(doctor);
        }

        public async Task<IEnumerable<DoctorViewModel>> GetDoctorsByConsultingRoomId(int id)
        {
            var doctors = await _repository.GetDoctorsByConsultingRoomIdAsync(id);

            return doctors.Select(x => new DoctorViewModel
            {
                Cedula = x.Cedula,
                Name = x.Name,
                PhoneNumber = x.PhoneNumber,
                ConsultingRoomId = x.ConsultingRoomId,
                Email = x.Email,
                LastName = x.LastName,
                Picture = x.Picture,
                Id = x.Id
            }).ToList() ?? Enumerable.Empty<DoctorViewModel>();
        }
    }
}
