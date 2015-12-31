using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet_Backend.Dao
{
    /// <summary>
    /// 
    /// </summary>
    public class DaoRol : Dao
    {
        /// <summary>
        /// 
        /// </summary>
        private Model.itbsEntities context;

        /// <summary>
        /// 
        /// </summary>
        public DaoRol()
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
            var Rol = from rol in context.RolSet1 where PrimaryKey==rol.Nombre select rol;
            return Rol;
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
            throw new NotImplementedException();
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