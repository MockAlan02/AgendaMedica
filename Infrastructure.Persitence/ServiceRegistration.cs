using AgendaMedica.Core.Application.Interface.Repository;
using Infrastructure.Persitence.Contexts;
using Infrastructure.Persitence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persitence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            #region Context
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ScheduleAppointmentContext>(option =>


                option.UseInMemoryDatabase("IdentityConnection"));
            }
            else
            {
                services.AddDbContext<ScheduleAppointmentContext>(option =>
                option.UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                b => b.MigrationsAssembly(typeof(ScheduleAppointmentContext).Assembly.FullName)));
            }
            #endregion
            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IDoctorRepository, DoctorRepository>();
            services.AddTransient<ILaboratorytestRepository, LaboratorytestRepository>();
            services.AddTransient<ILaboratoryResultRepository,LaboratoryResultRepository >();
            services.AddTransient<IAppointmentsRepository, AppointmentsRepository>();
            #endregion
        }
    }
}
