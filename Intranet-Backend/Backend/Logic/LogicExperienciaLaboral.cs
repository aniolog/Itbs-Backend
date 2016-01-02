using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Logic
{
    public class LogicExperienciaLaboral
    {
        /// <summary>
        /// 
        /// </summary>
        private Dao.Dao MyDao;

        /// <summary>
        /// 
        /// </summary>
        public LogicExperienciaLaboral()
        {
            this.MyDao = Dao.DaoFabric.getDaoExperienciaLaboral();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Correo"></param>
        /// <returns></returns>
        public IQueryable<Model.ExprecienciaLaboral> GetExperience(String Correo)
        {
            return this.MyDao.GetByPK(Correo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Study"></param>
        /// <returns></returns>
        public Boolean InsertExperience(Model.ExprecienciaLaboral Experience)
        {
            Experience.User = (new Logic.LogicUser()).GetUser(Experience.User.Correo);
            return this.MyDao.Insert(Experience);
        }
    }
}