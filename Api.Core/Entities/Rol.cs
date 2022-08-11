using Api.Core.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Core.Entities
{
    [Table("Rol")]
    public class Rol : Entity<int>
    {
        public string Nombre { get; set; }

        public List<Usuario> Usuarios { get; set; }
    }
}
