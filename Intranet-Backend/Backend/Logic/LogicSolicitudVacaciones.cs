using Backend.CACSMSR;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Xml;

namespace Backend.Logic
{
    public class LogicSolicitudVacaciones
    {
        private Dao.Dao MyDao;

        public LogicSolicitudVacaciones()
        {
            this.MyDao = Dao.DaoFabric.getDaoSolicitudVacaciones();
        }


        public List<Model.SolicitudVacaciones> GetVacationRequest(String Email) {
          return  this.MyDao.GetByPK(Email);
        }


        public string GetTicket(string ticketID) {
            try {
                var request = new CACSMSR.ServiceRequest();

                Credentials credentials = new Credentials();
                ExtendedSettings extParams = new ExtendedSettings();

                //  ObjectFactory factory = new ObjectFactory();

                // Initialize Credentials (User Name & User Password / Authorization Token & Slice Token)
                credentials.userName = "wsConnect40121";
                credentials.userPassword = "Itbs123!";

                // Initialize Extended Settings such as Response Format (XML, JSON)
                extParams.responseFormat = "JSON";

                // Invoke the GET service
                DefaultServiceResponse serviceResponse = request.getServiceRequest(credentials, extParams, "100-17");

                // Inspect successful execution of service and retrieve the response text serviceResponse.responseText
                if (serviceResponse.responseStatus == "OK")
                {


                    var jss = new JavaScriptSerializer();
                    var table = jss.Deserialize<dynamic>(serviceResponse.responseText);
                    return table[42];

                } // Retrieve the status code, status message and error messages, in case of failures 
                else {

                    throw new IntranetException.ItbsException(HttpStatusCode.InternalServerError, IntranetException.ExceptionResource.CsmTicketError + " Razon:"+ serviceResponse.statusMessage);
                 //   Console.Out.WriteLine("Errors : " + Arrays.asList(serviceResponse.errors.ToString()));
                }
            
        } catch (Exception e) {
                throw new IntranetException.ItbsException(HttpStatusCode.InternalServerError, IntranetException.ExceptionResource.CsmTicketError + " Razon:" + e.Message);
            }


}

        public void GetTicket2(string ticketID)
        {
            
        }

        public HttpWebRequest CreateWebRequest()
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"http://dev.nl/Rvl.Demo.TestWcfServiceApplication/SoapWebService.asmx");
            webRequest.Headers.Add(@"SOAP:Action");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }




        /*

        public Boolean InsertVacationRequest(Model.SolicitudVacaciones Request) {
            Logic.LogicDiaFeriado DiasFeriadosLogic = new Logic.LogicDiaFeriado();
            DateTime Fecha_Fin = Request.Fecha_Inicio;
            DateTime Fecha_Ingreso = (new LogicEmpleado())
                .GetEmpleado(Request.User.Correo).First().fecha_ing; 

            if (Request.User == null)
            {
                throw new IntranetException.ItbsException(HttpStatusCode.BadRequest,
                    IntranetException.ExceptionResource.UsuarioInvalido);
            }

            if (Request.Fecha_Inicio<=DateTime.Now) {
                throw new IntranetException.ItbsException(HttpStatusCode.BadRequest, 
                    IntranetException.ExceptionResource.FechaInicioInvalida);
            }

            if (Request.Duracion <= 0) {
                throw new IntranetException.ItbsException(HttpStatusCode.BadRequest, 
                    IntranetException.ExceptionResource.FechaInicioInvalida);
            }

            while (DiasFeriadosLogic.isFeriado(Request.Fecha_Inicio)) {
                Request.Fecha_Inicio=Request.Fecha_Inicio.AddDays(1);
            }

            for (int Arreglo = 0; Arreglo < Request.Duracion; Arreglo++) {
                Fecha_Fin = Fecha_Fin.AddDays(1);
                while (DiasFeriadosLogic.isFeriado(Fecha_Fin))
                {
                    Fecha_Fin = Fecha_Fin.AddDays(1);
                }
            }

            return this.MyDao.Insert(Request);
        }*/

    }
}