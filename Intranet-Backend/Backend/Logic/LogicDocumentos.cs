using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;

namespace Backend.Logic
{
    public class LogicDocumentos
    {
        private byte[] generatePDF(string Html) {
            var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
            htmlToPdf.PageHeight = 11;
            var pdfBytes = htmlToPdf.GeneratePdf(Html);
            return pdfBytes;
        }


        public string CreateConstanciaTrabajo(string User,string Boss) {

             Model.snemple Empleado = ((new Logic.LogicEmpleado()).GetEmpleado(User.ToUpper()).First());
             Model.snemple Jefe = ((new Logic.LogicEmpleado()).GetEmpleado(Boss.ToUpper()).First());
            if ((Jefe==null)||(User==null)) {
                throw new IntranetException.ItbsException(HttpStatusCode.BadRequest, 
                    IntranetException.ExceptionResource.EmpleadoInexistente); }
            var Html = System.IO.File.ReadAllText(LogicResources.TemplatesURL+LogicResources.CtFile);
            Html=Html.Replace("{Titulo}",(Empleado.sexo=="M" ? "el Sr" : "la Sra"));
            Html=Html.Replace("{Nacionalidad}", (Empleado.nac == 1 ? "V" : "E"));
            Html=Html.Replace("{Cedula}",Empleado.ci);
            var Cargo = ((Model.sncargo)(new Dao.DaoCargo()).GetByPK(Empleado.co_cargo)).des_cargo;
            Html = Html.Replace("{Cargo}", Cargo.ToLower());
            var nombres = Empleado.nombres.Split(' ');
            var apellidos = Empleado.apellidos.Split(' ');
            var nombreCompleto = "";
            for (int loop=0;loop<nombres.Length;loop++) {
                nombreCompleto = nombreCompleto + UtilFunctions.NameToFormat(nombres[loop])+" ";
            }
            for (int loop = 0; loop < apellidos.Length; loop++)
            {
                nombreCompleto = nombreCompleto + UtilFunctions.NameToFormat(apellidos[loop]) + " ";
            }
            Html = Html.Replace("{Nombre}",nombreCompleto);
            var nombreJefe= UtilFunctions.NameToFormat(Jefe.nombres.Split(' ')[0])+" "+UtilFunctions.NameToFormat(Jefe.apellidos.Split(' ')[0]);
            Html = Html.Replace("{JefeNombre}",nombreJefe );
            Html = Html.Replace("{JefeCedula}", Jefe.ci);
            Html = Html.Replace("{DiaIngreso}", UtilFunctions.DateTimeFormat(Empleado.fecha_ing));
            Html = Html.Replace("{DiaExpedicion}", UtilFunctions.DateTimeFormat(DateTime.Now.AddMonths(3)));

            byte[] pdfBytes=this.generatePDF(Html); ;
            System.IO.FileStream _FileStream =
            new System.IO.FileStream(Logic.LogicResources.DocumentsUrl+Empleado.correo_e+Logic.LogicResources.DocumentsOutPutFormat,
            System.IO.FileMode.Create, System.IO.FileAccess.Write);
            _FileStream.Write(pdfBytes, 0, pdfBytes.Length);
            _FileStream.Close();
            return (Empleado.correo_e + Logic.LogicResources.DocumentsOutPutFormat);

        }




    }
}