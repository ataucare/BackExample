using Api.Core.Entities.Base;

namespace Api.Core.Entities
{
    public class MenuRol : Entity<int>
    {
        public Menu Menu { get; set; }
        public int MenuId { get; set; }

        public Rol Rol { get; set; }
        public int RolId { get; set; }

        public bool Enabled { get; set; }
    }
}
