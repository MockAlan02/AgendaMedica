using AgendaMedica.Core.Domain.Commo;

namespace AgendaMedica.Core.Domain.Entities
{
    public class Doctor : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty ;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Cedula { get; set; } = string.Empty;
        public string Picture { get; set; } = string.Empty;

        public int ConsultingRoomId { get; set; }
        public ConsultingRoom ConsultingRoom { get; set; } = null!;
        public ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();

    }
}
