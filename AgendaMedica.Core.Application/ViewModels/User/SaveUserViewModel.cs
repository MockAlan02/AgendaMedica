

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Timers;

namespace AgendaMedica.Core.Application.ViewModels.User
{
    public class SaveUserViewModel
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

        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        [DisplayName("Nombre Usuario")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [DisplayName("Contraseña")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage ="Confirmar la contraseña es obligatorio")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        [DisplayName("Confirmar contraseña")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre del consultorio es requerido")]
        [DisplayName("Nombre Consultorio")]
        public string ConsultingName {  get; set; } = string.Empty;
        public int ConsultingRoomId { get; set; }

        [Required(ErrorMessage = "El rol es obligatorio.")]
        [DisplayName("Rol")]
        public int RoleId { get; set; }
    }
}
