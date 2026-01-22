using System.ComponentModel.DataAnnotations;

namespace EFconASPyMVC.Models
{
    public class Hermano

    {
        //Clave primaria
        [Key]
        public int Id { get; set; }

        //Demás atributos
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellidos { get; set; }

        [Required]
        public string DNI { get; set; }

        public string FechaNacimiento { get; set; }

        public string Telefono { get; set; }
        [Required]
        public string Email { get; set; }

        //Clave foránea
        public int HermandadId { get; set; }


        //Propiedad navegacional
        public Hermandad Hermandad { get; set; }


        public Tunica Tunica { get; set; }
        public List<PuestoHermano> PuestosHermanos { get; set; }

    }
}
