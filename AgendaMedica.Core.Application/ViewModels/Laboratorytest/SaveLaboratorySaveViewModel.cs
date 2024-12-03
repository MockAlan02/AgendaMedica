

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgendaMedica.Core.Application.ViewModels.Laboratorytest
{
    public class SaveLaboratorySaveViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [DisplayName("Nombre")]
        public string Name { get; set; } = string.Empty;

     
        public int ConsultingRoomId { get; set; }
    }
}
