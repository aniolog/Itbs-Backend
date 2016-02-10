using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Routing;

namespace Backend.ActionFilters
{
    public class Filter: System.Web.Http.Filters.ActionFilterAttribute
    {

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            Dao.Dao LogDao = Dao.DaoFabric.getDaoLog();
            string action = actionContext.ControllerContext.Controller.ToString();
            string method= actionContext.Request.Method.Method;
            string user = HttpContext.Current.User.Identity.Name;
            string path = actionContext.Request.RequestUri.ToString();
            DateTime Timestamp = DateTime.Now;

            Model.Log Action = new Model.Log()
            {
                Metodo = method,
                UserCorreo = user,
                Url = path,
                Descripcion = "Acceso a controlador:" + action,
                Hora=Timestamp,
                Tipo="Acceso"
            };
            //LogDao.Insert(Action);

        }
        

    }
}