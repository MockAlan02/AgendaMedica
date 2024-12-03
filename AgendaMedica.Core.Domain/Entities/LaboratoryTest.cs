using AgendaMedica.Core.Domain.Commo;

namespace AgendaMedica.Core.Domain.Entities
{
    public class LaboratoryTest : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public int ConsultingRoomId { get; set; }
        public ConsultingRoom ConsultingRoom { get; set; } = null!;
        public List<LaboryTestAppointment>? LaboryTestAppointments { get; } = new();
        public ICollection<LaboratoryResult> LaboratoryResults { get; set; } = new HashSet<LaboratoryResult>();

    }
}
