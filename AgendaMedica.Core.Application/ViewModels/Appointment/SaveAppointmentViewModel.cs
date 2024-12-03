
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace AgendaMedica.Core.Application.ViewModels.Appoiment
{
    public class SaveAppointmentViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El paciente es obligatorio.")]
        [DisplayName("Paciente")]
       
        public int PatientId { get; set; }

        [Required(ErrorMessage = "El doctor es obligatorio.")]
        [DisplayName("Doctor")]
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "La fecha de la cita es obligatoria.")]
        [DisplayName("Fecha Cita")]
        public DateTime DateAppointment { get; set; }

        [Required(ErrorMessage = "Debe agregar una causa")]
        [StringLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres.")]
        [DisplayName("Descripcion")]
      
        public string Description { get; set; } = string.Empty;

        public int StatusId { get; set; }

        public int ConsultingRoomId { get; set; }
    }
}
