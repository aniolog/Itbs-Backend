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
        [Route("{ItbsEmail}")]
        public IQueryable<Model.ExprecienciaLaboral> Get([FromUri] string ItbsEmail)
        {
            Logic.LogicExperienciaLaboral MyLogic = new Backend.Logic.LogicExperienciaLaboral();
            return MyLogic.GetExperience(ItbsEmail);
        }

        [Route("create")]
        public Boolean Post([FromBody] Model.ExprecienciaLaboral Experience)
        {
            Logic.LogicExperienciaLaboral MyLogic = new Backend.Logic.LogicExperienciaLaboral();
            return MyLogic.InsertExperience(Experience);
        }
    }
}
