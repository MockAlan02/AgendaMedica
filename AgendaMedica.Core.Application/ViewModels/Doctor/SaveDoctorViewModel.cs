
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgendaMedica.Core.Application.ViewModels.Doctor
{
    public class SaveDoctorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [DisplayName("Nombre")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [DisplayName("Apellido")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        [DisplayName("Correo Electronico")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "El número de teléfono es obligatorio.")]
        [Phone(ErrorMessage = "El formato del número de teléfono no es válido.")]
        [DisplayName("Numero Telefono")]

        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "La cédula es obligatoria.")]
        [RegularExpression("^[0-9]{3}-?[0-9]{7}-?[0-9]{1}$", ErrorMessage = "El formato de la cédula no es válido.")]
        [DisplayName("Cedula")]
        public string Cedula { get; set; } = string.Empty;


        [DataType(DataType.Upload)]

        public IFormFile FormFile { get; set; }

        public string Picture { get; set; } = string.Empty;

        public int ConsultingRoomId { get; set; }
    }
}
