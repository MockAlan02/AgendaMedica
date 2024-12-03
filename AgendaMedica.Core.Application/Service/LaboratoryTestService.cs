

using AgendaMedica.Core.Application.Interface.Repository;
using AgendaMedica.Core.Application.Interface.Service;
using AgendaMedica.Core.Application.ViewModels.Laboratorytest;
using AgendaMedica.Core.Domain.Entities;

namespace AgendaMedica.Core.Application.Service
{
    public class LaboratoryTestService : IGenericService<SaveLaboratorySaveViewModel, LaboratoryTestViewModel>, ILaboratoryTestService
    {
        private readonly ILaboratorytestRepository _repository;
        private readonly ILaboratoryResultService _resultService;

        public LaboratoryTestService(ILaboratorytestRepository repository, ILaboratoryResultService resultService)
        {
            _repository = repository;
            _resultService = resultService;
        }
        public async Task Add(SaveLaboratorySaveViewModel vm)
        {
            LaboratoryTest test = new LaboratoryTest()
            {
                ConsultingRoomId = vm.ConsultingRoomId,
                Name = vm.Name,
            };
            await _repository.AddAsync(test);
        }

        public async Task Delete(int id)
        {
            await _resultService.DeleteResultsByLaboratoryTestId(id);
            await _repository.DeleteAsync(id);
        }

        public async Task<List<LaboratoryTestViewModel>> GetAllViewModel()
        {
            IEnumerable<LaboratoryTest> laboratoryTests = await _repository.GetAllAsync();
            return laboratoryTests.Select(x => new LaboratoryTestViewModel()
            {
                Name = x.Name,
                ConsultingRoomId = x.ConsultingRoomId
            }).ToList();

        }

        public async Task<SaveLaboratorySaveViewModel> GetByIdSaveViewModel(int id)
        {
            LaboratoryTest laboratoryTest = await _repository.GetByIdAsync(id);
            return new SaveLaboratorySaveViewModel()
            {
                Id = laboratoryTest.Id,
                Name = laboratoryTest.Name,
                ConsultingRoomId = laboratoryTest.ConsultingRoomId,

            };
        }

        public async Task Update(SaveLaboratorySaveViewModel vm)
        {
            var laboratory = await _repository.GetByIdAsync(vm.Id);
            laboratory.Name = vm.Name;
            await _repository.UpdateAsync(laboratory);
        }

        public async Task<IEnumerable<LaboratoryTestViewModel>> GetTestsByConsultingRoomId(int id)
        {
            var tests = await _repository.GetTestsByConsultingRoomId(id);
            return tests.Select(x => new LaboratoryTestViewModel
            {
                ConsultingRoomId = x.ConsultingRoomId,
                Name = x.Name,
                Id = x.Id
            }).ToList() ?? Enumerable.Empty<LaboratoryTestViewModel>();
        }
    }
}
