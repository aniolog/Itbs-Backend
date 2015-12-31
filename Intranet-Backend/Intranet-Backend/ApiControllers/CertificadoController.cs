using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Intranet_Backend.ApiControllers
{
    public class CertificadoController:ApiController
    {
        [HttpGet]
        [Queryable]
        public IQueryable<Model.Certificado> Get(string Correo)
        {
            var Logic = new Logic.LogicCertificado();
            return Logic.GetCertificados(Correo);

        }



    }
}