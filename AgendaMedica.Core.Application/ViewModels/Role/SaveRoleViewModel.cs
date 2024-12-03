using System.ComponentModel.DataAnnotations;

namespace AgendaMedica.Core.Application.ViewModels.Role
{
    public class SaveRoleViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del rol es obligatorio.")]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
