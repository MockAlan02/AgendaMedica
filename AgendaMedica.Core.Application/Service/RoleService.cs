

using AgendaMedica.Core.Application.Interface.Repository;
using AgendaMedica.Core.Application.Interface.Service;
using AgendaMedica.Core.Application.ViewModels.Role;
using AgendaMedica.Core.Domain.Entities;

namespace AgendaMedica.Core.Application.Service
{
    public class RoleService : IGenericService<SaveRoleViewModel, RoleViewModel>, IRoleService
    {
        private readonly IGenericRepository<Role> _repository;
        public RoleService(IGenericRepository<Role> repository)
        {
            _repository = repository;
        }
        public async Task Add(SaveRoleViewModel vm)
        {
            Role role = new()
            {
                Description = vm.Description,
                Name = vm.Name,

            };
            await _repository.AddAsync(role);
        }

        public async Task Delete(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<RoleViewModel>> GetAllViewModel()
        {
            IEnumerable<Role> roles = await _repository.GetAllAsync();
            return roles.Select(x => new RoleViewModel()
            {
                Id = x.Id,
                Name = x.Name!
            }).ToList();
        }

        public async Task<SaveRoleViewModel> GetByIdSaveViewModel(int id)
        {
            var role = await _repository.GetByIdAsync(id);
            return new SaveRoleViewModel()
            {
                Id = role.Id,
                Name = role.Name!,
                Description = role.Description!
            };
        }

        public async Task Update(SaveRoleViewModel vm)
        {
            Role role = new()
            {
                Description = vm.Description,
                Name = vm.Name,
                Id = vm.Id
            };
            await _repository.UpdateAsync(role);
        }
    }
}
