using AgendaMedica.Core.Domain.Commo;

namespace AgendaMedica.Core.Domain.Entities
{
    public class ConsultingRoom : BaseEntity
    {
        public string Name { get; set; } = "";
        public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
        public ICollection<Patient> Patients { get; set; } = new List<Patient>();
       public ICollection<LaboratoryTest> LaboratoryTests { get; set; } = new List<LaboratoryTest>();
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        public ICollection<LaboratoryResult> LaboratoryResult { get; set; } = new HashSet<LaboratoryResult>();
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
