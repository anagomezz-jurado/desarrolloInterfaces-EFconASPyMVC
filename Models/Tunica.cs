using System.ComponentModel.DataAnnotations;

namespace EFconASPyMVC.Models
{
    public class Tunica
    {
        //Clave primaria
        [Key]
        public int Id { get; set; }

        //Demás atributos
        [Required]
        public string Color { get; set; }
        [Required]
        public string Talla { get; set; }
        [Required]
        public string Material { get; set; }
        [Required]
        public string FechaEntrega { get; set; }
        [Required]
        public bool Estado { get; set; }

        //Clave foránea
        public int HermanoId { get; set; }

        //Propiedad navegacional
        public Hermano Hermano { get; set; }
    }
}
