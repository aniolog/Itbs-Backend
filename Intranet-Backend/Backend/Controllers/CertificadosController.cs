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
        [Route("{email}/")]
        public IQueryable<Model.Certificado> Get([FromUri] string email) {
           Logic.LogicCertificado MyLogic = new Backend.Logic.LogicCertificado();
            return MyLogic.GetCertificados(email);
        }
        
        [Route("create")]
        public Boolean Post([FromBody] Model.Certificado Cert){
            Logic.LogicCertificado MyLogic = new Backend.Logic.LogicCertificado();
            return MyLogic.InsertCertificado(Cert);
        }
        


    }
}
