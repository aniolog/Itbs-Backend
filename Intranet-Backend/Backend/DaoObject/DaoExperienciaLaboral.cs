using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Dao
{
    /// <summary>
    /// Clase encargada de la persistencia de la experiencia laboral de los empleados
    /// </summary>
    public class DaoExperienciaLaboral:Dao
    {
        /// <summary>
        /// Contexto de la base de datos intranet
        /// </summary>
        private Model.ModelbackupContainer context;
        
        /// <summary>
        /// Constructor encargado de inicializar el contexto
        /// </summary>
        public DaoExperienciaLaboral()
        {
            context = Dao.IntranetContext;

        }

        /// <summary>
        /// Metodo no implementado
        /// </summary>
        /// <param name="PrimaryKey"></param>
        /// <returns></returns>
        public override bool Delete(string PrimaryKey)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo no implementado
        /// </summary>
        /// <returns></returns>
        public override dynamic GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo encargado de devolver la experiencia laboral de un empleado
        /// </summary>
        /// <param name="PrimaryKey">Correo del empleado</param>
        /// <returns>Lista con la experiencia laboral del empleado</returns>
        public override dynamic GetByPK(string PrimaryKey)
        {
            var Exp = from exp in context.ExprecienciaLaboralSet where PrimaryKey.Equals(exp.User.Correo) select exp;
            return Exp;
        }

        /// <summary>
        /// Metodo no implementado
        /// </summary>
        /// <returns></returns>
        public override int HowMany()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo encargado de insertar una experiencia laboral de un empleado
        /// </summary>
        /// <param name="obj">Experencia Laboral</param>
        /// <returns>retorna True si se pudo insertar</returns>
        public override bool Insert(object obj)
        {
            try
            {
                Model.ExprecienciaLaboral MyExp = (Model.ExprecienciaLaboral)obj;
                this.context.ExprecienciaLaboralSet.Add(MyExp);
                this.context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Metodo no implementado
        /// </summary>
        /// <param name="Obj"></param>
        /// <returns></returns>
        public override bool Update(object Obj)
        {
            throw new NotImplementedException();
        }
    }
}