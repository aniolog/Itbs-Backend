using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Backend.Logic
{
    public class LogicSolicitudVacaciones
    {
        private Dao.Dao MyDao;

        public LogicSolicitudVacaciones()
        {
            this.MyDao = Dao.DaoFabric.getDaoSolicitudVacaciones();
        }


        public List<Model.SolicitudVacaciones> GetVacationRequest(String Email) {
          return  this.MyDao.GetByPK(Email);
        }

        public Boolean InsetVacationRequest(Model.SolicitudVacaciones Request) {
            if (Request.User == null)
            {
                throw new IntranetException.ItbsException(HttpStatusCode.BadRequest, IntranetException.ExceptionResource.UsuarioInvalido);
            }
            return this.MyDao.Insert(Request);
        }

    }
}