using Api.Core.DTOs;

namespace Api.Core.DTOs
{
    public class Menu
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public int Orden { get; set; }
        public List<MenuItem> MenuItem { get; set; }
    }
}
