
using System.ComponentModel.DataAnnotations;

namespace AgendaMedica.Core.Application.ViewModels.User
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El usuario es requerido")]
        public string UserName { get; set;}
        [Required(ErrorMessage ="La contraseña es requerida")]
        public string Password { get; set;}
    }
}
