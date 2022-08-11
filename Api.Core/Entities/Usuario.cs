using Api.Core.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Core.Entities
{
    [Table("Usuario")]
    public class Usuario : Entity<int>
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Rut { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        public string? Username { get; set; }
        public int? Anexo { get; set; }
        public int RolId { get; set; }
        public Rol Rol { get; set; }
        public int LocacionId { get; set; }
        public Locacion Locacion { get; set; }
    }
}
