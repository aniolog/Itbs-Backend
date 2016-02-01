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
        public IQueryable<Model.SolicitudVacaciones> GetRequests(String Correo) {

            IQueryable<Model.SolicitudVacaciones> requestList=this.MyDao.GetByPK(Correo);
           
            return requestList;
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String LogServiceRequest(Model.SolicitudVacaciones req) {
            try
            {
                var request = new CACSMSR.ServiceRequest();

                Credentials credentials = new Credentials();
                ExtendedSettings extParams = new ExtendedSettings();
                
                credentials.userName = LogicResources.CsmUsername;
                credentials.userPassword = LogicResources.CsmPassword;
                extParams.responseFormat = Logic.LogicResources.ResponseFormat;

                ServiceRequest1 sqr = new ServiceRequest1();
                sqr.ticket_description = "prueba";
                sqr.description_long = "details";
                sqr.requester_name = "Lozano, Anibal";
                sqr.ccti_class = Logic.LogicResources.CctiClass;
                sqr.ccti_category =Logic.LogicResources.CctiCategory;
                sqr.ccti_type = Logic.LogicResources.CctiType;
                
                DefaultServiceResponse serviceResponse = request.logServiceRequest(credentials,extParams,sqr);

              
                if (serviceResponse.responseStatus == "OK")
                {


                    var jss = new JavaScriptSerializer();
                    var table = jss.Deserialize<dynamic>(serviceResponse.responseText);
                    var returner = table[0];
                    return returner[Logic.LogicResources.TicketIdentifier];
           

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        public Boolean SubmitVacationRequest(Model.SolicitudVacaciones Request) {
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

            if (Request.Fecha_Inicio < DateEntered) {
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Email"></param>
        public void UpdateRequestStatus(String Email)
        {
            IQueryable<Model.SolicitudVacaciones> DaysRequestedList = MyDao.GetByPK(Email);
            foreach (Model.SolicitudVacaciones Requested in DaysRequestedList)
            {
                if (((Requested.Estatus != "Vacaciones Aprobadas") &&
                     (Requested.Estatus != "No Aprobadas")))
                {
                    Requested.Estatus = this.GetTicketStatus(Requested.Ticket_id);
                }
            }
            this.MyDao.Update(null);
        }



        private int DaysAvailable(Model.SolicitudVacaciones Request, DateTime DateEntered) {
            int Available = 0;
            int DaysRequested = 0;
            var YearsIn= (Request.Fecha_Inicio- DateEntered).TotalDays / 365.2425;
            for (int Year = 0; Year < YearsIn-1; Year++) {
                Available = Available + Year + 15;
            }

            IQueryable<Model.SolicitudVacaciones> DaysRequestedList = MyDao.GetByPK(Request.User.Correo);
            foreach (Model.SolicitudVacaciones Requested in DaysRequestedList)
            {
                if (Requested.Estatus == "Vacaciones Aprobadas")
                {
                    var p=1 + 1;
                }
            }

            return Available;
        }

    }
}