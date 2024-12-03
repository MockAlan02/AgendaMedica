

using System.ComponentModel.DataAnnotations;

namespace AgendaMedica.Core.Application.ViewModels.User.Admin
{
    public class CreateUserViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio.")]

        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es obligatorio.")]

        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Confirmar la contraseña es obligatorio")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "El rol es obligatorio.")]
        public int RoleId { get; set; }
        public int ConsultingRoomId { get; set; }
    }
}
