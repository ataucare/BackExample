using Api.Core.Entities.Base;

namespace Api.Core.Entities
{
    public class MenuItem : Entity<int>
    {
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string Url { get; set; }
        public int Orden { get; set; }
        public DateTime Creacion { get; set; }

        public Menu Menu { get; set; }
        public int MenuId { get; set; }
    }
}
