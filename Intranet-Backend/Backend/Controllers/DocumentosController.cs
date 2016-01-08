using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend.Controllers
{
    [RoutePrefix("api/documentos")]
    public class DocumentosController : ApiController
    {
        [Authorize(Roles ="Administrador")]
        [Route("cv")]
        public string Post([FromBody] Model_Rest.CtRequest Request)
        {
         
            return (new Logic.LogicDocumentos()).CreateConstanciaTrabajo(Request.EmpleadoCorreo, Request.JefeCorreo);
        }
      
    }
    
}



