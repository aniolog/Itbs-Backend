using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend.Controllers
{
    [RoutePrefix("api/proyectos")]
    public class ProyectosController : ApiController
    {

        [ActionFilters.Filter]
        [Authorize(Roles = "Empleado,Administrador,RecursosHumanos")]
        [Route("create")]
        public Boolean Post([FromBody] Model.Proyectos Project)
        {
            Logic.LogicProyectos MyLogic = new Backend.Logic.LogicProyectos();
            return MyLogic.SaveProyect(Project);
        }

    }
}
