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

        [Queryable]
        [Route("perfil")]
        [Authorize]
        public IQueryable<Model.snemple> GetProfile()
        {
            Logic.LogicEmpleado MyLogic = new Backend.Logic.LogicEmpleado();
            return MyLogic.GetEmpleado(HttpContext.Current.User.Identity.Name);
        }
        
        [Authorize(Roles = "Administrador,RecursosHumanos")]
        [Queryable]
        [Route("{ItbsEmail}")]
        public IQueryable<Model.snemple> Get([FromUri] string ItbsEmail)
        {
            Logic.LogicEmpleado MyLogic = new Backend.Logic.LogicEmpleado();
            return MyLogic.GetEmpleado(ItbsEmail);
        }

        [Authorize(Roles = "Administrador,RecursosHumanos")]
        [Queryable]
        [Route("")]
        public IQueryable<Model.snemple> Get()
        {
            Logic.LogicEmpleado MyLogic = new Backend.Logic.LogicEmpleado();
            return MyLogic.GetAllEmpleados();
        }

        [Authorize]
        [Route("update")]
        public Boolean Put([FromBody]Model.snemple Employee)
        {
            Logic.LogicEmpleado MyLogic = new Backend.Logic.LogicEmpleado();
            return MyLogic.ModifyEmpleado(Employee);
        }

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
