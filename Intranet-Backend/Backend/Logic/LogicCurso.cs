using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Logic
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
        public IQueryable<Model.Curso> GetCursos(String UserEmail)
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
            Course.User = (new Logic.LogicUser()).GetUser(Course.User.Correo);
            return this.MyDao.Insert(Course);
        }
    }
}