using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_BirthDay.Dao
{
    class DaoEmployee
    {
        static private Model.ITPRUEB_NEntities context = new Model.ITPRUEB_NEntities();
        public static List<Model.snemple> GetAllBirthDayEmployee()
        {
            var Empleados = from empleados in context.snemple where 
                            empleados.fecha_nac.Day==DateTime.Now.Day &&
                            empleados.fecha_nac.Month == DateTime.Now.Month &&
                            empleados.fecha_egr == null
                            select empleados;
            return Empleados.ToList();
        }

        public static List<Model.snemple> GetAllNotBirthDayEmployee(Model.snemple BirthDayEmployee)
        {
            var Empleados = from empleados in context.snemple where
                            empleados.cod_emp!=BirthDayEmployee.cod_emp &&
                            empleados.fecha_egr == null
                            select empleados;
            return Empleados.ToList();
        }
    }
}
