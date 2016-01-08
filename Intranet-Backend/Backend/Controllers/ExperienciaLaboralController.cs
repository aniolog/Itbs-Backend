using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend.Controllers
{
    [RoutePrefix("api/experiencia")]
    public class ExperienciaLaboralController : ApiController
    {
        [Authorize(Roles = "Empleado,Administrador,RecursosHumanos")]
        [Queryable]
        [Route("{ItbsEmail}")]
        public IQueryable<Model.ExprecienciaLaboral> Get([FromUri] string ItbsEmail)
        {
            Logic.LogicExperienciaLaboral MyLogic = new Backend.Logic.LogicExperienciaLaboral();
            return MyLogic.GetExperience(ItbsEmail);
        }

        [Authorize(Roles = "Empleado,Administrador,RecursosHumanos")]
        [Route("create")]
        public Boolean Post([FromBody] Model.ExprecienciaLaboral Experience)
        {
            Logic.LogicExperienciaLaboral MyLogic = new Backend.Logic.LogicExperienciaLaboral();
            return MyLogic.InsertExperience(Experience);
        }
    }
}
