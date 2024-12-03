using AgendaMedica.Core.Application.ViewModels.User;

namespace AgendaMedica.Core.Application.Interface.Service
{
    public interface IUserService : IGenericService<SaveUserViewModel, UserViewModel>
    {
        Task<UserViewModel> Login(LoginViewModel loginVm);
        Task<bool> ConfirmUsernameExist(string username);
        Task<IEnumerable<UserViewModel>> GetAllUserByIdConsulting(int id);
    }
}