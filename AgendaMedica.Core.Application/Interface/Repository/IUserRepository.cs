using AgendaMedica.Core.Application.ViewModels.User;
using AgendaMedica.Core.Domain.Entities;

namespace AgendaMedica.Core.Application.Interface.Repository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> LoginAsync(LoginViewModel loginViewModel);
        Task<bool> ConfirmUsernameExist(string username);
        Task<IEnumerable<User>> GetAllUserByIdConsultRoom(int id);
    }
}