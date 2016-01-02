using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend.Controllers
{
    [RoutePrefix("api/cursos")]
    public class CursosController : ApiController
    {

        [Route("{ItbsEmail}")]
        public IQueryable<Model.Curso> Get([FromUri] string ItbsEmail)
        {
            Logic.LogicCurso MyLogic = new Backend.Logic.LogicCurso ();
            return MyLogic.GetCursos(ItbsEmail);
        }

        [Route("create")]
        public Boolean Post([FromBody] Model.Curso Course)
        {
            Logic.LogicCurso MyLogic = new Backend.Logic.LogicCurso();
            return MyLogic.InsertCurso(Course);
        }

    }
}
