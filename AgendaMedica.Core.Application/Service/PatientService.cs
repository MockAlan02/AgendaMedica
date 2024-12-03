using AgendaMedica.Core.Application.Interface.Repository;
using AgendaMedica.Core.Application.Interface.Service;
using AgendaMedica.Core.Application.ViewModels.Patient;
using AgendaMedica.Core.Application.ViewModels.User;
using AgendaMedica.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using AgendaMedica.Core.Application.Helpers;


namespace AgendaMedica.Core.Application.Service
{
    public class PatientService : IGenericService<SavePatienViewModel, PatientViewModel>, IPatientService
    {
        private readonly IGenericRepository<Patient> _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserViewModel userViewModel;
        private readonly IAppointmentService _appointmentService;
        public PatientService(IGenericRepository<Patient> repository, 
            IHttpContextAccessor httpContextAccessor,
            IAppointmentService appointmentService)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("user");
            _appointmentService = appointmentService;
        }
        public async Task Add(SavePatienViewModel vm)
        {
            Patient patient = new()
            {
                Allergy = vm.Allergy,
                BirthDate = vm.BirthDate,
                Cedula = vm.Cedula,
                ConsultingRoomId = userViewModel.ConsultingRoomId,
                LastName = vm.LastName,
                Name = vm.Name,
                Direction = vm.Direction,
                PhoneNumber = vm.PhoneNumber,
                Picture = vm.Picture,
                Smoke = vm.Smoke,


            };
            await _repository.AddAsync(patient);
        }
        public async Task<SavePatienViewModel> AddAsync(SavePatienViewModel vm)
        {
            Patient patient = new()
            {
                Allergy = vm.Allergy,
                BirthDate = vm.BirthDate,
                Cedula = vm.Cedula,
                ConsultingRoomId = userViewModel.ConsultingRoomId,
                LastName = vm.LastName,
                Name = vm.Name,
                Direction = vm.Direction,
                PhoneNumber = vm.PhoneNumber,
                Picture = vm.Picture,
                Smoke = vm.Smoke,


            };
            var patientVm = await _repository.AddAsync(patient);
            return new SavePatienViewModel
            {
                Allergy = patientVm.Allergy,
                BirthDate = patientVm.BirthDate,
                Cedula = patientVm.Cedula,
                ConsultingRoomId = patientVm.ConsultingRoomId,
                LastName = patientVm.LastName,
                Name = patientVm.Name,
                Direction = patientVm.Direction,
                PhoneNumber = patientVm.PhoneNumber,
                Picture = patientVm.Picture,
                Smoke = patientVm.Smoke,
                Id = patientVm.Id
            };
        }

        public async Task Delete(int id)
        {
            await _appointmentService.DeleteAppointmentByPatientId(id);
            await _repository.DeleteAsync(id);
        }

        public async Task<List<PatientViewModel>> GetAllViewModel()
        {
            IEnumerable<Patient> patients = await _repository.GetAllAsync();
            return patients.Select(patient => new PatientViewModel
            {
                Allergy = patient.Allergy,
                BirthDate = patient.BirthDate,
                Cedula = patient.Cedula,
                ConsultingRoomId = patient.ConsultingRoomId,
                LastName = patient.LastName,
                Name = patient.Name,
                Direction = patient.Direction,
                PhoneNumber = patient.PhoneNumber,
                Picture = patient.Picture,
                Smoke = patient.Smoke,
                Id = patient.Id
            }).ToList() ?? Enumerable.Empty<PatientViewModel>().ToList();
        }

        public async Task<SavePatienViewModel> GetByIdSaveViewModel(int id)
        {
            var patient = await _repository.GetByIdAsync(id);
            return new SavePatienViewModel()
            {
                Id = id,
                Smoke = patient.Smoke,
                Allergy = patient.Allergy,
                BirthDate = patient.BirthDate,
                Cedula = patient.Cedula,
                ConsultingRoomId = patient.ConsultingRoomId,
                LastName = patient.LastName,
                Name = patient.Name,
                Direction = patient.Direction,
                PhoneNumber = patient.PhoneNumber,
                Picture = patient.Picture
            };
        }

        public async Task Update(SavePatienViewModel vm)
        {
            Patient patient = await _repository.GetByIdAsync(vm.Id);


            patient.Id = vm.Id;
            patient.Allergy = vm.Allergy;
            patient.BirthDate = vm.BirthDate;
            patient.Cedula = vm.Cedula;
            patient.ConsultingRoomId = vm.ConsultingRoomId;
            patient.LastName = vm.LastName;
            patient.Name = vm.Name;
            patient.Direction = vm.Direction;
            patient.PhoneNumber = vm.PhoneNumber;
            
            if (vm.Picture != "")
            {
                patient.Picture = vm.Picture;
            }

            patient.Smoke = vm.Smoke;


            await _repository.UpdateAsync(patient);

        }
        public async Task<IEnumerable<PatientViewModel>> GetPatientsByConsultingId(int id)
        {
            var patients = await _repository.GetAllAsync();
            var patientsConsulting = patients.Where(x => x.ConsultingRoomId == id).ToList();

            return patientsConsulting.Select(x => new PatientViewModel
            {
                Id = x.Id,
                Allergy = x.Allergy,
                BirthDate = x.BirthDate,
                Cedula = x.Cedula,
                ConsultingRoomId = x.ConsultingRoomId,
                Direction = x.Direction,
                LastName = x.LastName,
                Name = x.Name,
                Picture = x.Picture,
                PhoneNumber = x.PhoneNumber,
                Smoke = x.Smoke,
            }).ToList() ?? Enumerable.Empty<PatientViewModel>();
        }
    }
}
