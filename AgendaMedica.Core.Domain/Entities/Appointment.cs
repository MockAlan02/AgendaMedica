using AgendaMedica.Core.Domain.Commo;

namespace AgendaMedica.Core.Domain.Entities
{
    public class Appointment : BaseEntity
    {
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        public DateTime DateAppointment {  get; set; }
    
        public string Description { get; set; } = "";
        public int StatusId { get; set; }
        public Status? Status {  get; set; }
        public int ConsultingRoomId { get; set; }
        public ConsultingRoom ConsultingRoom { get; set; } = null!;

       public  List<LaboryTestAppointment> LaboryTestAppointments { get; } = new();
        public List<LaboratoryResult> LaboratoryResult { get; set;} = new();
    }
}
