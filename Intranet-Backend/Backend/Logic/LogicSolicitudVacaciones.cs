using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
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


        public  void GetTicket(string ticketID) {
            HttpWebRequest request = CreateWebRequest();
            XmlDocument soapEnvelopeXml = new XmlDocument();
            string xml = System.IO.File.ReadAllText(@"C:\Users\alozano\Desktop\templates\ct.html");
            xml = xml.Replace("{ID}", ticketID);
            soapEnvelopeXml.LoadXml(xml);

            using (Stream stream = request.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    string soapResult = rd.ReadToEnd();
                    Console.WriteLine(soapResult);
                }
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