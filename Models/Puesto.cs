namespace EFconASPyMVC.Models
{
    public class Puesto
    {
        //Clave primaria
        public int Id { get; set; }

        //Demás atributos

        public string NombrePuesto { get; set; }
        public string Descripcion { get; set; }


        //Clave foránea
        public List<PuestoHermano> PuestosHermanos { get; set; }

    }
}
