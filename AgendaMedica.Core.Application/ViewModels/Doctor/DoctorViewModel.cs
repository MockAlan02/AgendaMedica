namespace AgendaMedica.Core.Application.ViewModels.Doctor
{
    public class DoctorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Cedula { get; set; } = string.Empty;
        public string Picture { get; set; } = null!;
        public int ConsultingRoomId { get; set; }
        public string ConsultingRoomName { get; set; } = string.Empty;
    }
}
