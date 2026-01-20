namespace EFconASPyMVC.Models
{
    public class Hermano

    {
        //Clave primaria
        public int Id { get; set; }

        //Demás atributos

        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public string FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public int HermandadId { get; set; }

        public Hermandad Hermandad { get; set; }

        //Clave foránea
        public List<PuestoHermano> PuestosHermanos { get; set; }

    }
}
