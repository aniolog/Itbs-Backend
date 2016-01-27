using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Dao
{
    /// <summary>
    /// 
    /// </summary>
    public class DaoSolicitudVacaciones:Dao
    {
        /// <summary>
        /// 
        /// </summary>
        Model.ModelbackupContainer context;

        /// <summary>
        /// 
        /// </summary>
        public DaoSolicitudVacaciones()
        {
            this.context = Dao.IntranetContext;
        }

        /// <summary>
        /// 
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PrimaryKey"></param>
        /// <returns></returns>
        public override dynamic GetByPK(string PrimaryKey)
        {
            var Vacaciones = from vacaciones in context.SolicitudVacacionesSet where vacaciones.User.Correo==PrimaryKey orderby vacaciones.Fecha_Inicio descending select vacaciones;
            return Vacaciones;
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
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            try {
               Model.SolicitudVacaciones Request=(Model.SolicitudVacaciones)obj;
               this.context.SolicitudVacacionesSet.Add(Request);
               this.context.SaveChanges();
               return true;
            }
            catch (Exception e) {
                throw e;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Obj"></param>
        /// <returns></returns>
        public override bool Update(object Obj)
        {
            throw new NotImplementedException();
        }
    }
}