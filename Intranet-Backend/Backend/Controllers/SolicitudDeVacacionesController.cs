using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Backend.Controllers
{
    [RoutePrefix("api/vacaciones")]
   
    public class SolicitudDeVacacionesController : ApiController
    {
        [Authorize(Roles = "Empleado,Administrador,RecursosHumanos")]
        [Route("")]
        [Queryable]
        public IQueryable<Model_Rest.SolicitudVacaciones> GetRequest() {
            Logic.LogicSolicitudVacaciones Logic = new Backend.Logic.LogicSolicitudVacaciones();
            return Logic.GetRquests(HttpContext.Current.User.Identity.Name);
        }

        [Authorize(Roles = "Empleado,Administrador,RecursosHumanos")]
        [Route("count")]
        [Queryable]
        public int GetCount()
        {
            Logic.LogicSolicitudVacaciones Logic = new Backend.Logic.LogicSolicitudVacaciones();
            return Logic.GetCount(HttpContext.Current.User.Identity.Name);
        }

        [Authorize(Roles = "Empleado,Administrador,RecursosHumanos")]
        [Route("create")]
        [Queryable]
        public String SaveRequest()
        {
            Logic.LogicSolicitudVacaciones Logic = new Backend.Logic.LogicSolicitudVacaciones();
            return Logic.LogServiceRequest();
        }


    }
}
