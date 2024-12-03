using AgendaMedica.Core.Application.Interface.Service;
using AgendaMedica.Core.Application.Service;
using Microsoft.Extensions.DependencyInjection;


namespace AgendaMedica.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            #region Services

            services.AddTransient<IAppointmentService, AppointmentService>();
            services.AddTransient<IDoctorService, DoctorService>();
            services.AddTransient<ILaboratoryTestService, LaboratoryTestService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IStatusService, StatusService>();
            services.AddTransient<IConsultingRoomService, ConsultingRoomService>();
            services.AddTransient<ILaboratoryResultService, LaboratoryResultService>();
            services.AddTransient<IAppointmentService, AppointmentService>();
            #endregion
        }
    }
}
