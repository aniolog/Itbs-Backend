using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend.Controllers
{
    [RoutePrefix("api/certificados")]
    public class CertificadosController : ApiController
    {
        [Route("{ItbsEmail}")]
        public Boolean Get() {
            throw new IntranetException.ItbsException(HttpStatusCode.BadGateway,"dasdasdasdas");
        }
    }
}
