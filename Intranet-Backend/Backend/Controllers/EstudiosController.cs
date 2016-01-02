using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend.Controllers
{
    [RoutePrefix("api/estudios")]
    public class EstudiosController : ApiController
    {
        [Route("{ItbsEmail}")]
        public IQueryable<Model.Estudio> Get([FromUri] string ItbsEmail)
        {
            Logic.LogicEstudio MyLogic = new Backend.Logic.LogicEstudio();
            return MyLogic.GetStudys(ItbsEmail);
        }

        [Route("create")]
        public Boolean Post([FromBody] Model.Estudio Study)
        {
            Logic.LogicEstudio MyLogic = new Backend.Logic.LogicEstudio();
            return MyLogic.InsertStudy(Study);
        }
    }
}
