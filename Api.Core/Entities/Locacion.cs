using Api.Core.Entities.Base;

namespace Api.Core.Entities
{
    public class Locacion : Entity<int>
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
    }
}
