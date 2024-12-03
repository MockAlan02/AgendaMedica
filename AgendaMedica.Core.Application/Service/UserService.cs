
using AgendaMedica.Core.Application.Helpers;
using AgendaMedica.Core.Application.Interface.Repository;
using AgendaMedica.Core.Application.Interface.Service;
using AgendaMedica.Core.Application.ViewModels.User;
using AgendaMedica.Core.Domain.Entities;

namespace AgendaMedica.Core.Application.Service
{
    public class UserService : IGenericService<SaveUserViewModel, UserViewModel>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IGenericRepository<ConsultingRoom> _consultingRepo;

        public UserService(IUserRepository userRepository, IGenericRepository<ConsultingRoom> consultingRepo)
        {
            _userRepository = userRepository;
            _consultingRepo = consultingRepo;
        }

        public async Task Add(SaveUserViewModel vm)
        {
            string password = PasswordEncryptations.ComputeSha256Hash(vm.Password);
            User user = new()
            {
                Name = vm.Name,
                LastName = vm.LastName,
                Email = vm.Email,
                RoleId = vm.RoleId,
                Username = vm.Username,
                ConsultingRoomId = vm.ConsultingRoomId,
                Password = password,
            };
            await _userRepository.AddAsync(user);
        }

        public async Task Delete(int id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<List<UserViewModel>> GetAllViewModel()
        {
            var list = await _userRepository.GetAllAsync();
            return list.Select(x => new UserViewModel
            {
                Name = x.Name,
                LastName = x.LastName,
                Email = x.Email,
                RoleId = x.RoleId,
                Username = x.Username,
                Password = x.Password
            }).ToList();
        }

        public async Task<SaveUserViewModel> GetByIdSaveViewModel(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return new SaveUserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                RoleId = user.RoleId,
                Username = user.Username,
                Password = user.Password,
                ConsultingRoomId = user.Id

            };
        }

        public async Task Update(SaveUserViewModel vm)
        {
            User user = await _userRepository.GetByIdAsync(vm.Id)!;
            user.Id = vm.Id;
            user.Name = vm.Name;
            user.LastName = vm.LastName;
            user.Email = vm.Email;
            user.RoleId = vm.RoleId;
            user.Username = vm.Username;
            if (vm.Password != null)
            {
                string password = PasswordEncryptations.ComputeSha256Hash(vm.Password);
                user.Password = password;
            }
            await _userRepository.UpdateAsync(user);
        }

        public async Task<UserViewModel> Login(LoginViewModel loginVm)
        {
            loginVm.Password = PasswordEncryptations.ComputeSha256Hash(loginVm.Password);
            User login = await _userRepository.LoginAsync(loginVm);
            if (login != null)
            {
                UserViewModel user = new()
                {
                    Id = login.Id,
                    Name = login.Name,
                    LastName = login.LastName,
                    Email = login.Email,
                    RoleId = login.RoleId,
                    Username = login.Username,
                    Password = login.Password,
                    ConsultingRoomId = login.ConsultingRoomId
                };
                return user;
            }
            return null!;
        }
        public async Task<bool> ConfirmUsernameExist(string username)
        {
            return await _userRepository.ConfirmUsernameExist(username);
        }

        public async Task<IEnumerable<UserViewModel>> GetAllUserByIdConsulting(int id)
        {
            var users = await _userRepository.GetAllUserByIdConsultRoom(id);

            if (users == null)
            {
                return Enumerable.Empty<UserViewModel>();
            }

            return users.Select(x => new UserViewModel
            {
                Id = x.Id,
                Name = x.Name,
                LastName = x.LastName,
                Email = x.Email,
                RoleId = x.RoleId,
                Username = x.Username,
                Password = x.Password,
                ConsultingRoomId = x.ConsultingRoomId,
            }).ToList();
        }
    }
}
