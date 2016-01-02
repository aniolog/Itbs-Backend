using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Logic
{
    public class LogicEstudio
    {
        /// <summary>
        /// 
        /// </summary>
        private Dao.Dao MyDao;

        /// <summary>
        /// 
        /// </summary>
        public LogicEstudio()
        {
            this.MyDao = Dao.DaoFabric.getDaoEstudio();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Correo"></param>
        /// <returns></returns>
        public List<Model.Estudio> GetStudys(String Correo) {
            return this.MyDao.GetByPK(Correo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Study"></param>
        /// <returns></returns>
        public Boolean InsertStudy(Model.Estudio Study) {
            return this.MyDao.Insert(Study);
        }


    }
}