using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet_Backend.Logic
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
            return this.MyDao.Insert(Request);
        }

    }
}