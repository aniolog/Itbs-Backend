using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Dao
{
    /// <summary>
    /// Clase encargada de la persistencia de los Estudios de los empleados
    /// </summary>
    public class DaoEstudio:Dao
    {
        /// <summary>
        /// Contexto de la base de datos intranet
        /// </summary>
        private Model.itbsEntities context;

        /// <summary>
        /// Constructor encargado de inicializar el contexto
        /// </summary>
        public DaoEstudio()
        {
            this.context = Dao.IntranetContext;       
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
        /// Metodo encargado de devolver los niveles de estudio del empleado
        /// </summary>
        /// <param name="PrimaryKey">Correo ITBS del empleado</param>
        /// <returns>Lista con los niveles de estudio del empleado</returns>
        public override dynamic GetByPK(string PrimaryKey)
        {
            var Study = from study in context.EstudioSet where PrimaryKey.Equals(study.User.Correo) select study;
            return Study;
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
        /// Metodo encargado de insertar un nuevo nivel de estudio
        /// </summary>
        /// <param name="obj">Estudio</param>
        /// <returns>True si se pudo insertar con exito</returns>
        public override bool Insert(object obj)
        {
            try
            {
                Model.Estudio MyStudy = (Model.Estudio)obj;
                this.context.EstudioSet.Add(MyStudy);
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