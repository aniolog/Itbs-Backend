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
            MyDao = Dao.DaoFabric.getDaoSolicitudVacaciones();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public List<Model.SolicitudVacaciones> GetVacationRequest(String Email) {
          return  this.MyDao.GetByPK(Email);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ticketID"></param>
        /// <returns></returns>
        private string GetTicketStatus(string ticketID) {
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
                DefaultServiceResponse serviceResponse = request.getServiceRequest(credentials, extParams, ticketID);

                // Inspect successful execution of service and retrieve the response text serviceResponse.responseText
                if (serviceResponse.responseStatus == "OK")
                {


                    var jss = new JavaScriptSerializer();
                    var table = jss.Deserialize<dynamic>(serviceResponse.responseText);
                    var returner = table[0];
                    return returner["Reason Code"];

                } // Retrieve the status code, status message and error messages, in case of failures 
                else {

                    throw new IntranetException.ItbsException(HttpStatusCode.InternalServerError, IntranetException.ExceptionResource.CsmTicketError + " Razon:"+ serviceResponse.statusMessage);
                 //   Console.Out.WriteLine("Errors : " + Arrays.asList(serviceResponse.errors.ToString()));
                }
            
        } catch (Exception e) {
                throw new IntranetException.ItbsException(HttpStatusCode.InternalServerError, IntranetException.ExceptionResource.CsmTicketError + " Razon:" + e.Message);
            }


}
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Correo"></param>
        /// <returns></returns>
        public IQueryable<Model_Rest.SolicitudVacaciones> GetRquests(String Correo) {

            IQueryable<Model.SolicitudVacaciones> requestList=this.MyDao.GetByPK(Correo);
            List<Model_Rest.SolicitudVacaciones> returnList = new List<Model_Rest.SolicitudVacaciones>();
            foreach (Model.SolicitudVacaciones req in requestList) {
                string status = this.GetTicketStatus(req.Ticket_id);
                Model_Rest.SolicitudVacaciones newReq = 
                    new Model_Rest.SolicitudVacaciones(req.Id,req.Fecha_Inicio,req.Duracion,req.Ticket_id,status,req.Fecha_Fin);
                returnList.Add(newReq);
            }
            return returnList.AsQueryable();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Correo"></param>
        /// <returns></returns>
        public int GetCount(String Correo)
        {

            IQueryable<Model.SolicitudVacaciones> requestList = this.MyDao.GetByPK(Correo);
            return requestList.Count();
        }


        public String LogServiceRequest() {
            try
            {
                var request = new CACSMSR.ServiceRequest();

                Credentials credentials = new Credentials();
                ExtendedSettings extParams = new ExtendedSettings();
                
                credentials.userName = "wsConnect40121";
                credentials.userPassword = "Itbs123!";
                extParams.responseFormat = "JSON";

                ServiceRequest1 sqr = new ServiceRequest1();
                sqr.ticket_description = "prueba";
                sqr.description_long = "details";
                sqr.requester_name = "Lozano, Anibal";
                sqr.ccti_class = "Servicios de TI";
                sqr.ccti_category = "Solicitud";
                sqr.ccti_type = "Vacaciones";
                
                DefaultServiceResponse serviceResponse = request.logServiceRequest(credentials,extParams,sqr);

              
                if (serviceResponse.responseStatus == "OK")
                {


                    var jss = new JavaScriptSerializer();
                    var table = jss.Deserialize<dynamic>(serviceResponse.responseText);
                    var returner = table[0];
                    return returner["ticket_identifier"];
           

                } 
                else {
                    throw new IntranetException.ItbsException(HttpStatusCode.InternalServerError, IntranetException.ExceptionResource.CsmTicketError + " Razon:" + serviceResponse.statusMessage);
                }

            }
            catch (Exception e)
            {
                throw new IntranetException.ItbsException(HttpStatusCode.InternalServerError, IntranetException.ExceptionResource.CsmTicketError + " Razon:" + e.Message);
            }
        }
 
        public Boolean InsertVacationRequest(Model.SolicitudVacaciones Request) {
            Logic.LogicDiaFeriado DiasFeriadosLogic = new Logic.LogicDiaFeriado();
            DateTime EndDate = Request.Fecha_Inicio;
            DateTime DateEntered = (new LogicEmpleado())
                .GetEmpleado(Request.User.Correo).First().fecha_ing; 

            if (Request.User == null)
            {
                throw new IntranetException.ItbsException(HttpStatusCode.BadRequest,
                    IntranetException.ExceptionResource.UsuarioInvalido);
            }

            if (Request.Fecha_Inicio<=DateTime.Now) {
                throw new IntranetException.ItbsException(HttpStatusCode.BadRequest, 
                    "hola");
            }

            if (Request.Duracion <= 0) {
                throw new IntranetException.ItbsException(HttpStatusCode.BadRequest, 
                    "hola");
            }
            var YearsInItbs =(DateTime.Today -DateEntered).TotalDays/ 365.2425;
            if (!(YearsInItbs > 0)) {
                throw new IntranetException.ItbsException(HttpStatusCode.BadRequest,
                   "hola");
            }

            /*
            while ((DiasFeriadosLogic.isFeriado(Request.Fecha_Inicio))||
                    (Request.Fecha_Inicio.DayOfWeek==DayOfWeek.Saturday)||
                      (Request.Fecha_Inicio.DayOfWeek == DayOfWeek.Sunday)){
                        Request.Fecha_Inicio=Request.Fecha_Inicio.AddDays(1);
                     }
            
            for (int Arreglo = 0; Arreglo < Request.Duracion; Arreglo++) {
                Fecha_Fin = Fecha_Fin.AddDays(1);
                while (DiasFeriadosLogic.isFeriado(Fecha_Fin))
                {
                    Fecha_Fin = Fecha_Fin.AddDays(1);
                }
            }

            return this.MyDao.Insert(Request);*/
            return true;
        }

    }
}