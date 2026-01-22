using System.ComponentModel.DataAnnotations;

namespace EFconASPyMVC.Models
{
    public class Puesto
    {
        //Clave primaria
        [Key]
        public int Id { get; set; }

        //Demás atributos
        [Required]
        public string NombrePuesto { get; set; }

        [Required]
        public string Descripcion { get; set; }


        //Propiedad navegacional
        public List<PuestoHermano> PuestosHermanos { get; set; }

    }
}
