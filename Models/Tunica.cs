namespace EFconASPyMVC.Models
{
    public class Tunica
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public string Talla { get; set; }
        public string Material { get; set; }
        public string FechaEntrega { get; set; }
        public bool Estado { get; set; }
        public int HermanoId { get; set; }

        public Hermano Hermano { get; set; }
    }
}
