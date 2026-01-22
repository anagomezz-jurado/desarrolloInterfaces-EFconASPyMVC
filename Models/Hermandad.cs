using System.ComponentModel.DataAnnotations;

namespace EFconASPyMVC.Models
{
    public class Hermandad
    {
        //Clave primaria
        [Key]
        public int Id { get; set; }

        //Demás atributos
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Cif { get; set; }
        public string FechaFundacion { get; set; }
        public string Ciudad { get; set; }

        public List<Hermano> Hermanos { get; set; }

    }
}
