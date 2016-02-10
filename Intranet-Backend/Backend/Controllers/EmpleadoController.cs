using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace Backend.Controllers
{
    [RoutePrefix("api/empleados")]
    public class EmpleadoController : ApiController
    {

        [ActionFilters.Filter]
        [Queryable]
        [Route("perfil")]
        [Authorize]
        public IQueryable<Model.snemple> GetProfile()
        {
            Logic.LogicEmpleado MyLogic = new Backend.Logic.LogicEmpleado();
            return MyLogic.GetEmpleado(HttpContext.Current.User.Identity.Name);
        }


        [ActionFilters.Filter]
        [Authorize(Roles = "Administrador,RecursosHumanos")]
        [Queryable]
        [Route("{ItbsEmail}")]
        public IQueryable<Model.snemple> Get([FromUri] string ItbsEmail)
        {
            Logic.LogicEmpleado MyLogic = new Backend.Logic.LogicEmpleado();
            return MyLogic.GetEmpleado(ItbsEmail);
        }


        [ActionFilters.Filter]
        [Authorize(Roles = "Administrador,RecursosHumanos")]
        [Queryable]
        [Route("")]
        public IQueryable<Model.snemple> Get()
        {
            Logic.LogicEmpleado MyLogic = new Backend.Logic.LogicEmpleado();
            return MyLogic.GetAllEmpleados();
        }


        [ActionFilters.Filter]
        [Authorize]
        [Route("update")]
        public Boolean Put([FromBody]Model.snemple Employee)
        {
            Logic.LogicEmpleado MyLogic = new Backend.Logic.LogicEmpleado();
            return MyLogic.ModifyEmpleado(Employee);
        }


        [ActionFilters.Filter]
        [Authorize(Roles = "Administrador,RecursosHumanos")]
        [Queryable]
        [Route("count")]
        public int GetCount()
        {
            Logic.LogicEmpleado MyLogic = new Backend.Logic.LogicEmpleado();
            return MyLogic.HowManyEmployess();
        }

    }
}
