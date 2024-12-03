using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace AgendaMedica.Core.Application.ViewModels.ConsultingRoom
{
    public class SaveConsultingRoomViewModel
    {
        public int Id { get; set; }
       
        [Required(ErrorMessage = "El usuario debe Agregar un nombre del consultorio")]
        [DisplayName("Nombre Consultorio")]
      
        public string Name { get; set; }
    }
}
