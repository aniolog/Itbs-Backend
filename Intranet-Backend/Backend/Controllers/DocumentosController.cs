using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Backend.Controllers
{
    [RoutePrefix("api/documentos")]
    public class DocumentosController : ApiController
    {

        [ActionFilters.Filter]
        [Authorize(Roles ="Administrador")]
        [Route("ct/{ItbsEmail}")]
        [HttpGet]
        public string GenerateCT([FromUri] string ItbsEmail)
        {
            Logic.LogicDocumentos Logic = new Logic.LogicDocumentos();

            return Logic.CreateConstanciaTrabajo(ItbsEmail,
                HttpContext.Current.User.Identity.Name);
        }


        [ActionFilters.Filter]
        [Authorize(Roles = "Administrador")]
        [Route("cv/{ItbsEmail}")]
        [HttpGet]
        public string GenerateCV([FromUri] string ItbsEmail)
        {
            Logic.LogicDocumentos Logic = new Logic.LogicDocumentos();
            string FileName = Logic.CreateCurriculum(ItbsEmail);
            return FileName;
        }

    }
    
}



