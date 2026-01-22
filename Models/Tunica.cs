namespace EFconASPyMVC.Models
{
    public class Tunica
    {
        //Clave primaria
        public int Id { get; set; }

        //Demás atributos
        public string Color { get; set; }
        public string Talla { get; set; }
        public string Material { get; set; }
        public string FechaEntrega { get; set; }
        public bool Estado { get; set; }

        //Clave foránea
        public int HermanoId { get; set; }

        //Propiedad navegacional
        public Hermano Hermano { get; set; }
    }
}
