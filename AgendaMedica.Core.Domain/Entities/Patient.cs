

using AgendaMedica.Core.Domain.Commo;

namespace AgendaMedica.Core.Domain.Entities
{
    public class Patient : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Direction { get; set; } = string.Empty;
        public string Cedula { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public int ConsultingRoomId { get; set; }
        public ConsultingRoom ConsultingRoom { get; set; } = null!;
        public bool Smoke { get; set; }

        public bool Allergy { get; set; }
        public string Picture { get; set; } = string.Empty;
        public ICollection<LaboratoryResult> LaboratoryResults { get; set; } = new HashSet<LaboratoryResult>();
        public ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
    }
}
