

using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgendaMedica.Core.Application.ViewModels.Patient
{
    public class SavePatienViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [DisplayName("Nombre")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [DisplayName("Apellido")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "El número de teléfono es obligatorio.")]
        [Phone(ErrorMessage = "El formato del número de teléfono no es válido.")]
        [DisplayName("Numero Telefono")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "La dirección es obligatoria.")]
        [DisplayName("Direccion")]
        public string Direction { get; set; } = string.Empty;

        [Required(ErrorMessage = "La cédula es obligatoria.")]
        [DisplayName("Cedula")]
        public string Cedula { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        [DisplayName("Fecha Nacimiento")]
        public DateTime BirthDate { get; set; }


        [DataType(DataType.Upload)]

        public IFormFile FormFile { get; set; }
        
        public int ConsultingRoomId { get; set; }

        public bool Smoke { get; set; }

        public bool Allergy { get; set; }

        public string Picture { get; set; } = string.Empty;
    }
}
