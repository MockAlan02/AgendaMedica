

using AgendaMedica.Core.Domain.Commo;

namespace AgendaMedica.Core.Domain.Entities
{
    public class LaboratoryResult : BaseEntity
    {
        public string Result { get; set; } = string.Empty;
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int LaboratoryTestId { get; set; }
        public LaboratoryTest LaboratoryTest { get; set; }
        public int ConsultingRoomId { get; set; }
        public ConsultingRoom ConsultingRoomName { get; set; }

        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
        public bool Status { get; set; }
    }
}
