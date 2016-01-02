using System;
using System.Collections.Generic;
using System.Linq;
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
        /// <param name="User"></param>
        /// <returns></returns>
        public Boolean ModifyUser(Model.User User) {
            return this.Dao.Update(User);
        }

    }
}