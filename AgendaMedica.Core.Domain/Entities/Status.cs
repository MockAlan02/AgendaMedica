using AgendaMedica.Core.Domain.Commo;

namespace AgendaMedica.Core.Domain.Entities
{
    public class Status : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
    }
}
