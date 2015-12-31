using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet_Backend.Dao
{
    /// <summary>
    /// 
    /// </summary>
    public class DaoSolicitudVacaciones:Dao
    {
        /// <summary>
        /// 
        /// </summary>
        Model.itbsEntities context;

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
        /// <param name="Page"></param>
        /// <param name="Size"></param>
        /// <returns></returns>
        public override dynamic GetAll(int Page, int Size)
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
            var Vacaciones = from vacaciones in context.SolicitudVacacionesSet where PrimaryKey.Equals(vacaciones.User.Correo) select vacaciones;
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