

namespace AgendaMedica.Core.Application.ViewModels.LaboratoryResult
{
    public class LaboratoryResultViewModel
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string PatientLastName { get; set; }
        public string PatientCedula { get; set; }
        public bool Status { get; set; }
        public int AppointmentId { get; set; }
        public string TestName { get; set; }
    }
}
