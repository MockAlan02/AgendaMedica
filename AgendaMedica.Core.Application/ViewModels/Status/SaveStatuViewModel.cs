
using System.ComponentModel.DataAnnotations;

namespace AgendaMedica.Core.Application.ViewModels.Status
{
    public class SaveStatuViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del estado es obligatorio.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La descripción del estado es obligatoria.")]
        public string Description { get; set; }
    }
}
