using AgendaMedica.Core.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgendaMedica.Core.Application.ViewModels.LaboratoryResult
{
    public class SaveLaboratoryResultViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El resultado del laboratorio es obligatorio.")]
        [DisplayName("Resultado")]
        public string Result { get; set; }

 
        public int PatientId { get; set; }

   
        public int LaboratoryTestId { get; set; }

        public LaboratoryTest LaboratoryTest { get; set; }

        public int ConsultingRoomId { get; set; }

        public int AppoimentId { get; set; }
        public bool Status { get; set; }
    }
}
