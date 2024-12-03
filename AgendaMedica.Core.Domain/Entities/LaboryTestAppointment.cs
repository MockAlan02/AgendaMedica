
using AgendaMedica.Core.Domain.Commo;

namespace AgendaMedica.Core.Domain.Entities
{
    public class LaboryTestAppointment: BaseEntity
    {
        public int AppoinmentId { get; set; }
        public int LaboratoryTestId { get; set; }

        public Appointment? Appointment { get; set; } = null;
        public LaboratoryTest? LaboratoryTest { get; set; } = null;
    }
}
