namespace Api.Core.DTOs
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Url { get; set; }
        public int Orden { get; set; }
    }
}
