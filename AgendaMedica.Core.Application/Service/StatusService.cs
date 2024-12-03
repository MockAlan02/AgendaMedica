

using AgendaMedica.Core.Application.Interface.Repository;
using AgendaMedica.Core.Application.Interface.Service;
using AgendaMedica.Core.Application.ViewModels.Status;
using AgendaMedica.Core.Domain.Entities;

namespace AgendaMedica.Core.Application.Service
{
    public class StatusService : IGenericService<SaveStatuViewModel, StatusViewModel>, IStatusService
    {

        private readonly IGenericRepository<Status> _repository;
        public StatusService(IGenericRepository<Status> repository)
        {
            _repository = repository;
        }
        public async Task Add(SaveStatuViewModel vm)
        {
            Status status = new()
            {
                Description = vm.Description,
                Name = vm.Name,
            };
            await _repository.AddAsync(status);
        }

        public async Task Delete(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<StatusViewModel>> GetAllViewModel()
        {
            IEnumerable<Status> statuses = await _repository.GetAllAsync();
            return statuses.Select(x => new StatusViewModel()
            {
                Description = x.Description!,
                Name = x.Name!
            }).ToList();
        }

        public async Task<SaveStatuViewModel> GetByIdSaveViewModel(int id)
        {
            Status status = await _repository.GetByIdAsync(id);
            return new SaveStatuViewModel()
            {
                Id = status.Id,
                Name = status.Name!,
                Description = status.Description!
            };
        }

        public async Task Update(SaveStatuViewModel vm)
        {
            Status status = new()
            {
                Description = vm.Description,
                Name = vm.Name,
                Id = vm.Id,
            };
            await _repository.UpdateAsync(status);
        }
    }
}
