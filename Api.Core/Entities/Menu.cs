using Api.Core.Entities.Base;

namespace Api.Core.Entities
{
    public class Menu : Entity<int>
    {
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Icon { get; set; }
        public string? Url { get; set; }
        public int Orden { get; set; }
        public DateTime Creacion { get; set; }
        public List<MenuItem> MenuItem { get; set; }
    }
}
