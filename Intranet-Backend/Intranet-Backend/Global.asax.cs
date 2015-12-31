using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.WebHost;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Intranet_Backend
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.Re‌​ferenceLoopHandling = ReferenceLoopHandling.Ignore;
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configuration.Filters.Add(new IntranetException.ExceptionFilter());


            RouteTable.Routes.MapHttpRoute(
                name:"Vacacion Controller",
                routeTemplate:"intranet/{controller}/{id}",
                defaults: new {
                    controller="Vacaciones",
                    id =RouteParameter.Optional
                }
                );

            RouteTable.Routes.MapHttpRoute(
                name: "Certificados Controller",
                routeTemplate: "intranet/certificados/{Correo}",
                defaults: new
                {
                    id = RouteParameter.Optional,
                    controller = "Certificados"
                }
                );



        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        public override void Init()
        {
            base.Init();
        }
    
    
    }
}