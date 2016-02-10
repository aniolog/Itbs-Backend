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

        [ActionFilters.Filter]
        [Authorize(Roles = "Empleado,Administrador,RecursosHumanos")]
        [HttpGet]
        [Route("")]
        [Queryable]
        public IQueryable<Model.SolicitudVacaciones> GetRequest() {
            Logic.LogicSolicitudVacaciones Logic = new Backend.Logic.LogicSolicitudVacaciones();
            Logic.UpdateRequestStatus(HttpContext.Current.User.Identity.Name);
            return Logic.GetRequests(HttpContext.Current.User.Identity.Name);
        }


        [ActionFilters.Filter]
        [Authorize(Roles = "Empleado,Administrador,RecursosHumanos")]
        [HttpGet]
        [Route("count")]
        [Queryable]
        public int GetCount()
        {
            Logic.LogicSolicitudVacaciones Logic = new Backend.Logic.LogicSolicitudVacaciones();
            return Logic.GetCount(HttpContext.Current.User.Identity.Name);
        }


        [ActionFilters.Filter]
        [Authorize(Roles = "Empleado,Administrador,RecursosHumanos")]
        [HttpPost]
        [Route("create")]
        [Queryable]
        public String SaveRequest([FromBody]Model_Rest.RestSolicitudVacaciones Request)
        {
            Logic.LogicSolicitudVacaciones Logic = new Backend.Logic.LogicSolicitudVacaciones();
            return Logic.SubmitVacationRequest(Request);
          
        }


    }
}
