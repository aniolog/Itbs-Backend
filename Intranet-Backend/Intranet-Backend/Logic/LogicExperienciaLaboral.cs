using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet_Backend.Logic
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
        public List<Model.ExprecienciaLaboral> GetExperience(String Correo)
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
            return this.MyDao.Insert(Experience);
        }
    }
}