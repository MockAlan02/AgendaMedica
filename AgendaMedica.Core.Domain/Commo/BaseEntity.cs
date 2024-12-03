using System.ComponentModel.DataAnnotations;

namespace AgendaMedica.Core.Domain.Commo
{
    public class BaseEntity
    {
     [Key]
     public int Id {  get; set; }
    }
}
