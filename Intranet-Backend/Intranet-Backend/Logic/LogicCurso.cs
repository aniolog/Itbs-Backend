using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet_Backend.Logic
{
    public class LogicCurso
    {
        /// <summary>
        /// 
        /// </summary>
        private Dao.Dao MyDao;

        /// <summary>
        /// 
        /// </summary>
        public LogicCurso()
        {
            this.MyDao = Dao.DaoFabric.getDaoCurso();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserEmail"></param>
        /// <returns></returns>
        public List<Model.Curso> GetCursos(String UserEmail)
        {
            return this.MyDao.GetByPK(UserEmail);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Cert"></param>
        /// <returns></returns>
        public Boolean InsertCurso(Model.Curso Course)
        {
            return this.MyDao.Insert(Course);
        }
    }
}