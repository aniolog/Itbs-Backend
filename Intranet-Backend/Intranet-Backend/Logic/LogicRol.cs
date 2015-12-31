using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet_Backend.Logic
{
    public class LogicRol
    {
        /// <summary>
        /// 
        /// </summary>
        private Dao.Dao MyDao;

        /// <summary>
        /// 
        /// </summary>
        public LogicRol()
        {
            this.MyDao = Dao.DaoFabric.getDaoRol();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Tittle"></param>
        /// <returns></returns>
        public IQueryable<Model.Rol> GetRol(String Tittle)
        {
            return this.MyDao.GetByPK(Tittle);
        }
    }
}