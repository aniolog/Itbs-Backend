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
        [Authorize(Roles ="Administrador")]
        [Route("cv/{Email}")]
        public string Post([FromUri] string Email)
        {
            Logic.LogicDocumentos Logic = new Logic.LogicDocumentos();

            return Logic.CreateConstanciaTrabajo(Email,
                HttpContext.Current.User.Identity.Name);
        }
      
    }
    
}



