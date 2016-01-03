using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public IQueryable<Model.Estudio> GetStudys(String Correo) {
            return this.MyDao.GetByPK(Correo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Study"></param>
        /// <returns></returns>
        public Boolean InsertStudy(Model.Estudio Study) {
            if (Study.User == null)
            {
                throw new IntranetException.ItbsException(HttpStatusCode.BadRequest, IntranetException.ExceptionResource.UsuarioInvalido);
            }
            var User = (new Logic.LogicUser()).GetUser(Study.User.Correo);
            if (User == null)
            {
                throw new IntranetException.ItbsException(HttpStatusCode.NotFound, IntranetException.ExceptionResource.UsuarioInexistente);
            }
            Study.User = User;
            return this.MyDao.Insert(Study);
        }


    }
}