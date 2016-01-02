using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Backend.Logic
{
    /// <summary>
    /// Clase encargada de la logica de los usuarios de intranet
    /// </summary>
    public class LogicUser
    {
        /// <summary>
        /// 
        /// </summary>
        private Dao.DaoUser Dao;

        /// <summary>
        /// 
        /// </summary>
        public LogicUser()
        {
            this.Dao = new Backend.Dao.DaoUser();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="NewUser"></param>
        /// <returns></returns>
        public Boolean InsertUser(Model.User NewUser) {

            
                if (NewUser.Rol == null)
                {
                    throw new IntranetException.ItbsException(HttpStatusCode.BadRequest, IntranetException.ExceptionResource.RolInvalido);
                }

                var Rol = (new Logic.LogicRol()).GetRol(NewUser.Rol.Nombre);
                if (Rol.Count() == 0)
                {
                    throw new IntranetException.ItbsException(HttpStatusCode.BadRequest, IntranetException.ExceptionResource.RolInexistente);
                }
                NewUser.Rol = Rol.First();
                return this.Dao.Insert(NewUser);
            
           
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserEmail"></param>
        /// <returns></returns>
        public Model.User GetUser(String UserEmail) {
            return this.Dao.GetByPK(UserEmail);
        }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
        public IQueryable<Model.User> GetUsers()
        {
            return this.Dao.GetAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        public Boolean ModifyUser(Model.User User) {
            return this.Dao.Update(User);
        }

    }
}