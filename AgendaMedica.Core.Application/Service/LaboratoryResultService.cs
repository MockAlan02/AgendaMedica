

using AgendaMedica.Core.Application.Interface.Repository;
using AgendaMedica.Core.Application.Interface.Service;
using AgendaMedica.Core.Application.ViewModels.LaboratoryResult;
using AgendaMedica.Core.Domain.Entities;

namespace AgendaMedica.Core.Application.Service
{
    public class LaboratoryResultService : IGenericService<SaveLaboratoryResultViewModel, LaboratoryResultViewModel>, ILaboratoryResultService
    {
        private readonly ILaboratoryResultRepository _laboratoryResultRepository;
        public LaboratoryResultService(ILaboratoryResultRepository laboratoryResultRepository)
        {
            _laboratoryResultRepository = laboratoryResultRepository;
        }
        public async Task Add(SaveLaboratoryResultViewModel vm)
        {
            LaboratoryResult laboratoryResult = new()
            {
                ConsultingRoomId = vm.ConsultingRoomId,
                LaboratoryTestId = vm.LaboratoryTestId,
                PatientId = vm.PatientId,
                Result = vm.Result,
                Status = vm.Status,
                AppointmentId = vm.AppoimentId

            };
            await _laboratoryResultRepository.AddAsync(laboratoryResult);

        }

        public async Task Delete(int id)
        {
            await _laboratoryResultRepository.DeleteAsync(id);
        }

        public async Task<List<LaboratoryResultViewModel>> GetAllViewModel()
        {
            var results = await _laboratoryResultRepository.GetAllAsync();
            return results.Select(x => new LaboratoryResultViewModel
            {
                Id = x.Id,
                PatientCedula = x.Patient.Cedula,
                PatientLastName = x.Patient.LastName,
                PatientName = x.Patient.Name,
                TestName = x.LaboratoryTest.Name,
            }).ToList();
        }

        public async Task<SaveLaboratoryResultViewModel> GetByIdSaveViewModel(int id)
        {
            var results = await _laboratoryResultRepository.GetByIdAsync(id);

            return new SaveLaboratoryResultViewModel
            {
                ConsultingRoomId = results.ConsultingRoomId,
                Id = results.Id,
                LaboratoryTestId = results.LaboratoryTestId,
                PatientId = results.PatientId,
                Result = results.Result,
                Status = results.Status,
            };
        }

        public async Task Update(SaveLaboratoryResultViewModel vm)
        {
            var laboratoryResult = await _laboratoryResultRepository.GetByIdAsync(vm.Id);
            laboratoryResult.Status = vm.Status;
            laboratoryResult.Result = vm.Result;
            await _laboratoryResultRepository.UpdateAsync(laboratoryResult);
        }

        public async Task<IEnumerable<LaboratoryResultViewModel>> GetTestByConsultingRoomId(int id)
        {
            var results = await _laboratoryResultRepository.GetResultsLaboratoryByConsultingRoom(id);

            return results.Select(x => new LaboratoryResultViewModel
            {
                Id = x.Id,
                PatientCedula = x.Patient.Cedula,
                PatientLastName = x.Patient.LastName,
                PatientName = x.Patient.Name,
                TestName = x.LaboratoryTest.Name,
                Status = x.Status,
                AppointmentId = x.AppointmentId,

            }).ToList();
        }

        public async Task DeleteResultsByAppointmentId(int id)
        {
            var results = await _laboratoryResultRepository.GetAllAsync();
            var resultAppointment = results.Where(x => x.AppointmentId == id).ToList();
            foreach (LaboratoryResult item in resultAppointment)
            {
                await _laboratoryResultRepository.DeleteAsync(item.Id);
            }
        }
        public async Task DeleteResultsByLaboratoryTestId(int id)
        {
            var results = await _laboratoryResultRepository.GetAllAsync();
            var resultAppointment = results.Where(x => x.LaboratoryTestId == id).ToList();
            foreach (LaboratoryResult item in resultAppointment)
            {
                await _laboratoryResultRepository.DeleteAsync(item.Id);
            }
        }
        public async Task<IEnumerable<LaboratoryResultViewModel>> GetResultsByCedulaAsync(int consultingId, string cedula)
        {
            var results = await _laboratoryResultRepository.GetResultsLaboratoryByConsultingRoom(consultingId);
            var dataFromCedula = results.Where(x => x.Patient.Cedula.StartsWith(cedula) && x.Status != true).ToList();
            return dataFromCedula.Select(x => new LaboratoryResultViewModel
            {
                Id = x.Id,
                PatientCedula = x.Patient.Cedula,
                PatientLastName = x.Patient.LastName,
                PatientName = x.Patient.Name,
                TestName = x.LaboratoryTest.Name,
                Status = x.Status,
                AppointmentId = x.AppointmentId,

            }).ToList();
        }
    }
}
