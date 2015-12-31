using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Intranet_Backend.ApiControllers
{
    public class VacacionesController:ApiController
    {
        [HttpGet]
        [Queryable]
        public IQueryable<Model.Rol> Get(int id) {
            throw new IntranetException.ItbsException(HttpStatusCode.PartialContent,"Errosr");
            
            var Logic = new Logic.LogicRol();
            return Logic.GetRol("Empleado");
            
        }

        [HttpPost]
        public HttpResponseMessage Post(string hola,string epa) {
            return Request.CreateResponse(HttpStatusCode.OK, hola, Configuration.Formatters.JsonFormatter);

        }

    }
}