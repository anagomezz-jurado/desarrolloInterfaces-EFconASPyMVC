using System.ComponentModel.DataAnnotations;

namespace EFconASPyMVC.Models
{
    public class PuestoHermano
    {

        // Claves foráneas (y primaria compuesta)
        public int PuestoId { get; set; }
        public int HermanoId { get; set; }

        //Demás atributos
        [Required]
        public string FechaInicio { get; set; }

        [Required]
        public string FechaFin { get; set; }


        //Propiedades navegacionales
        public Puesto Puesto { get; set; }
        public Hermano Hermano { get; set; }
    }
}
