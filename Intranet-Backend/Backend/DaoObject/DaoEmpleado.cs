using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Dao
{
    /// <summary>
    /// 
    /// </summary>
    public class DaoEmpleado:Dao
    {
        /// <summary>
        /// 
        /// </summary>
        private Model.ITPRUEB_NEntities context;

        /// <summary>
        /// 
        /// </summary>
        public DaoEmpleado()
        {
            context = Dao.ProfitContext;
        }

        /// <summary>
        ///Metodo no implementado 
        /// </summary>
        /// <param name="PrimaryKey"></param>
        /// <returns></returns>
        public override bool Delete(string PrimaryKey)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override dynamic GetAll()
        {
            var Empleados = from empleados in context.snemple where empleados.fecha_egr == null select empleados;
            return Empleados.OrderBy(emp => emp.ci);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PrimaryKey"></param>
        /// <returns></returns>
        public override dynamic GetByPK(string PrimaryKey)
        {
            var Empleados = from empleados in context.snemple where empleados.correo_e.Equals(PrimaryKey) select empleados;
            return Empleados;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int HowMany()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///Metodo no implementado 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Obj"></param>
        /// <returns></returns>
        public override bool Update(object Obj)
        {
            try {
                Model.snemple MyEmployee = (Model.snemple)Obj;
                var Empleado = from empleado in context.snemple where empleado.correo_e.Equals(MyEmployee.correo_e) select empleado;
                Model.snemple UpdateEmployee = Empleado.First();
                UpdateEmployee.direccion = MyEmployee.direccion;
                UpdateEmployee.telefono = MyEmployee.telefono;
                UpdateEmployee.avisar_a = MyEmployee.avisar_a;
                UpdateEmployee.telf_contact = MyEmployee.telf_contact;
                context.SaveChanges();
                return true; }
            catch(Exception e) { throw e; }
        }
    }
}