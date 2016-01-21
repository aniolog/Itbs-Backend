using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Model_Rest
{
    public class UserEmpleado
    {
     
         public Model.Rol rol { get; set; }
         public string direccion { get; set; }
         public string telefono { get; set; }
         public string TelefonoCelular { get; set; }
         public string correo_e { get; set; }
         public string correo_personal { get; set; }
         public string avisar_a { get; set; }
         public string telf_contact { get; set; }
         public string ModeloVehiculo { get; set; }
         public string ColorVehiculo { get; set; }
         public string AnoVehiculo { get; set; }
         public string PlacaVehiculo { get; set; }
         public string CorreoPersonal { get; set; }
      


    }
}