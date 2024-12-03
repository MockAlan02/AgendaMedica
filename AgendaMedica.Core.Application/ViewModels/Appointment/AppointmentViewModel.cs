

namespace AgendaMedica.Core.Application.ViewModels.Appoiment
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string DoctorName { get; set; } = string.Empty; 
        public DateTime DateAppointment { get; set; }
        public string Description { get; set; } = string.Empty;
        public int StatusId { get; set; }
        public int ConsultingRoomId { get; set; }
    }
}
