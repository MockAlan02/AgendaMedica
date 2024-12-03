using AgendaMedica.Core.Application.ViewModels.Role;

namespace AgendaMedica.Core.Application.Interface.Service
{
    public interface IRoleService
    {
        Task Add(SaveRoleViewModel vm);
        Task Delete(int id);
        Task<List<RoleViewModel>> GetAllViewModel();
        Task<SaveRoleViewModel> GetByIdSaveViewModel(int id);
        Task Update(SaveRoleViewModel vm);
    }
}