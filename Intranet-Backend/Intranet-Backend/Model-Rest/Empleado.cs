using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet_Backend.Model_Rest
{
    public class Empleado
    {
         public string nombres { get; }
         public string apellidos { get; }
         public string ci { get; }
         public System.DateTime fecha_nac { get; }
         public System.DateTime fecha_ing { get; }
         public string direccion { get;  }
         public string telefono { get;}
         public string correo_e { get; }
         public string correo_personal { get; }
         public string avisar_a { get; }
         public string telf_contact { get; }
         public string ModeloVehiculo { get; }
         public string ColorVehiculo { get;}
         public string AnoVehiculo { get;}
         public string PlacaVehiculo { get; }
         public string Foto { get; }
         public string CorreoPersonal { get; }
        
        public  Empleado(Model.snemple Employee,Model.User User)
        {
            this.nombres = Employee.nombres;
            this.apellidos = Employee.apellidos;
            this.ci = Employee.ci;
            this.fecha_nac = Employee.fecha_nac;
            this.fecha_ing = Employee.fecha_ing;
            this.direccion = Employee.direccion;
            this.telefono = Employee.telefono;
            this.correo_e = Employee.correo_e;
            this.correo_personal = User.CorreoPersonal;
            this.avisar_a = Employee.avisar_a;
            this.telf_contact = Employee.telf_contact;
            this.ModeloVehiculo = User.ModeloVehiculo;
            this.ColorVehiculo = User.ModeloVehiculo;
            this.AnoVehiculo = User.AnoVehiculo;
            this.PlacaVehiculo = User.PlacaVehiculo;
            this.Foto = User.Foto;
            this.CorreoPersonal = User.CorreoPersonal;

    }

        static public List<Model_Rest.Empleado> ToRestModel(List<Model.snemple> Employees) {
            var LogicUser = new Logic.LogicUser();
            var List = (new Logic.LogicEmpleado()).GetAllEmpleados();
            var Returner = new List<Model_Rest.Empleado>();
            Model.User User;
            foreach (Model.snemple Employee in List) {
                User = LogicUser.GetUser(Employee.correo_e);
                Returner.Add(new Model_Rest.Empleado(Employee,User));
            }
            return Returner;
        }


    }
}