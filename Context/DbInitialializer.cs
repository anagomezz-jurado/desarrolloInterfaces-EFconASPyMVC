using EFconASPyMVC.Models;

namespace EFconASPyMVC.Context
{

    public class DbInitializer
    {
        public static void Initialize(MyDbContext context)
        {
            context.Database.EnsureCreated(); //este método nos crea automáticamente
                                              //la BD sin migraciones, pero éstas son preferibles por si nuestro modelo
                                              //se va modificando
                                              // Comprueba si hay algún instituto
            if (context.Hermandad.Any())
            {
                return; // BD ya ha sido inicializada
            }
            //Añado Hermandaddes 
            var hermandades = new Hermandad[]
            {
                 new Hermandad{Nombre="Hdad. Virgen de la Cabeza", Cif="A12345678", FechaFundacion="1950-05-15", Ciudad="Córdoba"},
                 new Hermandad{Nombre="Hdad. de la Vera Cruz", Cif="B23456789", FechaFundacion="1920-03-10", Ciudad="Sevilla"},
                 new Hermandad{Nombre="Hdad. de los Dolores", Cif="C34567890", FechaFundacion="1880-09-20", Ciudad="Málaga"},
                 new Hermandad{Nombre="Hdad. de la Soledad", Cif="D45678901", FechaFundacion="1910-12-05", Ciudad="Córdoba"},
                 new Hermandad{Nombre="Hdad. del Santo Cristo", Cif="E56789012", FechaFundacion="1905-04-12", Ciudad="Granada"},
                            };

            foreach (Hermandad i in hermandades)
            {
                context.Hermandad.Add(i);
            }
            context.SaveChanges();


         

            //Añado Hermanos
            var hermanos = new Hermano[]
            {
                 new Hermano{ Nombre = "Carson", Apellidos = "Smith",DNI = "12345678A",FechaNacimiento = "1995-01-15", Telefono = "600123456", Email = "carson@example.com", PuestosHermanos = new List<PuestoHermano>(), HermandadId=1},
                 new Hermano{ Nombre = "Meredith",Apellidos = "Grey",DNI = "23456789B",FechaNacimiento = "1996-03-22", Telefono = "600234567", Email = "meredith@example.com",PuestosHermanos = new List<PuestoHermano>(), HermandadId=2},
                 new Hermano{ Nombre = "Arturo", Apellidos = "Juarez", DNI = "34567890C",FechaNacimiento = "1997-07-10",Telefono = "600345678", Email = "arturo@example.com", PuestosHermanos = new List<PuestoHermano>(),  HermandadId=2},
                 new Hermano{ Nombre = "Gytis", Apellidos = "Barzdukas", DNI = "45678901D", FechaNacimiento = "1994-11-05",Telefono = "600456789",Email = "gytis@example.com",PuestosHermanos = new List<PuestoHermano>(), HermandadId = 3},
                 new Hermano{ Nombre = "Yan", Apellidos = "Li", DNI = "56789012E",FechaNacimiento = "1993-08-18",Telefono = "600567890", Email = "yan@example.com", PuestosHermanos = new List<PuestoHermano>(), HermandadId = 4},
                 new Hermano{Nombre = "Peggy",Apellidos = "Justice",DNI = "67890123F",FechaNacimiento = "1996-12-01",Telefono = "600678901", Email = "peggy@example.com", PuestosHermanos = new List<PuestoHermano>(), HermandadId = 1},
                 new Hermano{Nombre = "Laura",Apellidos = "Norman",DNI = "78901234G",FechaNacimiento = "1995-05-25",Telefono = "600789012",Email = "laura@example.com",PuestosHermanos = new List<PuestoHermano>(), HermandadId = 3}
            };


            foreach (Hermano h in hermanos)
            {
                context.Hermano.Add(h);
            }


            context.SaveChanges();

            //Añado Tunicas
            var tunicas = new Tunica[]
            {
    new Tunica { Color="Rojo", Talla="M", Material="Algodón", FechaEntrega="2026-01-20", Estado=true, HermanoId=2 },
    new Tunica { Color="Azul", Talla="L", Material="Seda", FechaEntrega="2026-01-22", Estado=true, HermanoId=3 },
    new Tunica { Color="Blanco", Talla="S", Material="Lino", FechaEntrega="2026-01-25", Estado=false, HermanoId=1 },
    new Tunica { Color="Verde", Talla="XL", Material="Poliéster", FechaEntrega="2026-01-28", Estado=true, HermanoId=4 },
    new Tunica { Color="Negro", Talla="M", Material="Algodón", FechaEntrega="2026-02-01", Estado=false, HermanoId=2 },
            };



            foreach (Tunica h in tunicas)
            {
                context.Tunica.Add(h);
            }

            context.SaveChanges();
            //Añado Puesto
            var puestos = new Puesto[]
{
            new Puesto{NombrePuesto="Presidente", Descripcion="Dirige la hermandad", PuestosHermanos = new List<PuestoHermano>()},
            new Puesto{NombrePuesto="Vicepresidente", Descripcion="Sustituye al presidente", PuestosHermanos = new List<PuestoHermano>()},
            new Puesto{NombrePuesto="Secretario", Descripcion="Gestiona documentación y actas", PuestosHermanos = new List<PuestoHermano>()},
            new Puesto{NombrePuesto="Tesorero", Descripcion="Gestiona las finanzas", PuestosHermanos = new List<PuestoHermano>()},
            new Puesto{NombrePuesto="Capellán", Descripcion="Asesora en temas religiosos", PuestosHermanos = new List<PuestoHermano>()},
            new Puesto{NombrePuesto="Vocal", Descripcion="Colabora en distintas comisiones", PuestosHermanos = new List<PuestoHermano>()},
            new Puesto{NombrePuesto="Hermano Mayor", Descripcion="Representante máximo de la hermandad", PuestosHermanos = new List<PuestoHermano>()}
        };

            foreach (Puesto d in puestos)
            {
                context.Puesto.Add(d);
            }
            context.SaveChanges();
            //Añado PuestoHermano
            var puestosHermanos = new PuestoHermano[]
        {
                 new PuestoHermano { PuestoId = 1, HermanoId = 3, FechaInicio = "2023-01-01", FechaFin = "2023-12-31" },
                 new PuestoHermano { PuestoId = 2, HermanoId = 5, FechaInicio = "2023-02-01", FechaFin = "2023-12-31" },
                new PuestoHermano { PuestoId = 3, HermanoId = 2, FechaInicio = "2023-03-01", FechaFin = "2023-12-31" }
        };
            foreach (PuestoHermano c in puestosHermanos)
            {
                context.PuestoHermano.Add(c);
            }
            context.SaveChanges();

        }
    }
}
