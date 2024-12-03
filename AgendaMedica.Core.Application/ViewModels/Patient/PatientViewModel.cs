namespace AgendaMedica.Core.Application.ViewModels.Patient
{
    public class PatientViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Direction { get; set; } = string.Empty;
        public string Cedula { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public int ConsultingRoomId { get; set; }
        public string ConsultingRoomName { get; set; } = string.Empty;  
        public bool Smoke { get; set; }
        public bool Allergy { get; set; }
        public string Picture { get; set; } = string.Empty;
    }
}
