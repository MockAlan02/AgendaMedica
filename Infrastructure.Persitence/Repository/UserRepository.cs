using AgendaMedica.Core.Application.Interface.Repository;
using AgendaMedica.Core.Application.ViewModels.User;
using AgendaMedica.Core.Domain.Entities;
using Infrastructure.Persitence.Contexts;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Persitence.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly DbSet<User> _user;

        public UserRepository(ScheduleAppointmentContext context) : base(context)
        {
            _user = context.Set<User>();
        }

        public async Task<User> LoginAsync(LoginViewModel loginViewModel)
        {
            return await _user.FirstOrDefaultAsync(x => x.Username == loginViewModel.UserName && x.Password == loginViewModel.Password)!;
        }

        public async Task<bool> ConfirmUsernameExist(string username)
        {
            return await _user.FirstOrDefaultAsync(x => x.Username.ToLower() == username.ToLower()) != null ;
        }

        public async Task<IEnumerable<User>> GetAllUserByIdConsultRoom(int id)
        {
            return await _user.Where(x => x.ConsultingRoomId == id).ToListAsync();
        }
    }
}
