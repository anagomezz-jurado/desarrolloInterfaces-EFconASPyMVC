namespace EFconASPyMVC.Models
{
    public class Puesto
    {
        //Clave primaria
        public int Id { get; set; }

        //Demás atributos

        public string NombrePuesto { get; set; }
        public string Descripcion { get; set; }


        //Propiedad de navegacional para desplegable
        public List<PuestoHermano> PuestosHermanos { get; set; }

    }
}
