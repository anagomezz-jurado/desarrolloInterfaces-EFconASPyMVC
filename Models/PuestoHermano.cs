namespace EFconASPyMVC.Models
{
    public class PuestoHermano
    {

        // Claves foráneas (y primaria compuesta)
        public int PuestoId { get; set; }
        public int HermanoId { get; set; }

        //Demás atributos

        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }


        //navegacion
        public Puesto Puesto { get; set; }
        public Hermano Hermano { get; set; }
    }
}
