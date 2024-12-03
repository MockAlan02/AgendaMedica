using AgendaMedica.Core.Domain.Commo;

namespace AgendaMedica.Core.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int ConsultingRoomId {  get; set; }
        public ConsultingRoom ConsultingRoom { get; set; } = null!;
        public int RoleId {  get; set; }
        public Role? Role { get; set; }
            
    }
}
