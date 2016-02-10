using NReco.PdfGenerator;
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
            #region Datos
            Html =Html.Replace("{Titulo}",(Empleado.sexo=="M" ? "el Sr" : "la Sra"));
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
            #endregion

            byte[] pdfBytes=this.generatePDF(Html); ;
            System.IO.FileStream _FileStream =
            new System.IO.FileStream(Logic.LogicResources.DocumentsUrl+Empleado.correo_e+Logic.LogicResources.DocumentsOutPutFormat,
            System.IO.FileMode.Create, System.IO.FileAccess.Write);
            _FileStream.Write(pdfBytes, 0, pdfBytes.Length);
            _FileStream.Close();
            return (Empleado.correo_e + Logic.LogicResources.DocumentsOutPutFormat);

        }

        public string CreateCurriculum(string User)
        {

            Model.snemple Empleado = ((new Logic.LogicEmpleado()).GetEmpleado(User).First());
            Model.User Usuario = (new Logic.LogicUser()).GetUser(User);
            var Html = System.IO.File.ReadAllText(LogicResources.TemplatesURL + LogicResources.CvFile);

            #region DatosPersonales
            Html = Html.Replace("{nombre}",Empleado.nombres);
            Html = Html.Replace("{apellido}", Empleado.apellidos);
            Html = Html.Replace("{direccion}",Empleado.direccion);
            Html = Html.Replace("{telefono}",Empleado.telefono);
            Html = Html.Replace("{itbscorreo}",Empleado.correo_e);
            Html = Html.Replace("{correopersonal}", Usuario.CorreoPersonal);
            Html = Html.Replace("{fechanacimiento}", 
                UtilFunctions.DateTimeFormat(Empleado.fecha_nac).Split(',')[1]);
            Html = Html.Replace("{lugarnac}", UtilFunctions.NameToFormat(Empleado.lugar_nac));
            if (Empleado.edo_civ == "S")
            {
                if (Empleado.sexo == "M")
                {
                    Html = Html.Replace("{edocivil}", "Soltero");
                }
                else {
                    Html = Html.Replace("{edocivil}", "Soltera");
                }
            }
            else {
                if (Empleado.sexo == "M")
                {
                    Html = Html.Replace("{edocivil}", "Casado");
                }
                else {
                    Html = Html.Replace("{edocivil}", "Casada");
                }
            }
            Html = Html.Replace("{fotoperfil}", Logic.LogicResources.FotosURL+Usuario.Foto);
            #endregion

            #region ExperienciaLaboral
            string ExperienciaLaboralBaseHtml = 
                System.IO.File.ReadAllText(LogicResources.TemplatesURL
                + LogicResources.ExperienciaLaboralTemplate);

            string ExperienciaLaboralHtml = "";
            string ExperienciaLaboralAppender = "";


            foreach (var exp in Usuario.ExprecienciaLaboral) {
                ExperienciaLaboralAppender = 
                    (string)ExperienciaLaboralBaseHtml.Clone();

                ExperienciaLaboralAppender = 
                    ExperienciaLaboralAppender.Replace("{empresa}",exp.Empresa);

                ExperienciaLaboralAppender =
                    ExperienciaLaboralAppender.Replace("{anoinicio}", 
                    exp.Ano_Inicio.Month+". "+exp.Ano_Inicio.Year);

                if (exp.Ano_Finalizacion == null)
                {
                    ExperienciaLaboralAppender =
                         ExperienciaLaboralAppender.Replace("{anofin}", "PRESENT");
                }
                else {
                    ExperienciaLaboralAppender =
                    ExperienciaLaboralAppender.Replace("{anofin}",
                    ((DateTime)exp.Ano_Finalizacion).Month + ". " +
                    ((DateTime)exp.Ano_Finalizacion).Year);
                }
                ExperienciaLaboralAppender =
                    ExperienciaLaboralAppender.Replace("{desempeno}", exp.Desempeno);
                ExperienciaLaboralAppender =
                    ExperienciaLaboralAppender.Replace("{descripcion}", exp.Descripcion);


                ExperienciaLaboralHtml = ExperienciaLaboralHtml + ExperienciaLaboralAppender;

            }
            #endregion

            #region FormacionAcademica
            string FormacionAcademicaBaseHtml =
                System.IO.File.ReadAllText(LogicResources.TemplatesURL
                + LogicResources.FormacionAcademicaTemplate);

            string FormacionAcademicaHtml = "";
            string FormacionAcademicaAppender = "";

            foreach (var academic in Usuario.Estudio) {

                FormacionAcademicaAppender =
                 (string)FormacionAcademicaBaseHtml.Clone();

                FormacionAcademicaAppender = 
                    FormacionAcademicaAppender.Replace("{institucion}",academic.Institucion);

                FormacionAcademicaAppender =
                    FormacionAcademicaAppender.Replace("{fechafin}",
                    academic.Ano_Finalizacion.Month+". "+ academic.Ano_Finalizacion.Year);

                FormacionAcademicaAppender =
                    FormacionAcademicaAppender.Replace("{titulo}", academic.Titulo);

                FormacionAcademicaHtml = FormacionAcademicaHtml + FormacionAcademicaAppender;


            }
            #endregion

            #region FormacionProfesional
            string FormacionProfesionalBaseHtml =
                System.IO.File.ReadAllText(LogicResources.TemplatesURL
                + LogicResources.FormacionProfesionalTemplate);

            string FormacionProfesionalHtml = "";
            string FormacionProfesionalAppender = "";

            foreach (var profesional in Usuario.Curso)
            {

                FormacionProfesionalAppender =
                 (string)FormacionProfesionalBaseHtml.Clone();

                FormacionProfesionalAppender =
                    FormacionProfesionalAppender.Replace("{anofin}",
                    profesional.Ano_Finalizacion.Year.ToString());

                FormacionProfesionalAppender =
                    FormacionProfesionalAppender.Replace("{curso}",
                    profesional.Titulo);

                FormacionProfesionalHtml = FormacionProfesionalHtml + FormacionProfesionalAppender;

            }
            #endregion

            #region Proyectos
            string ProyectoBaseHtml =
              System.IO.File.ReadAllText(LogicResources.TemplatesURL
              + LogicResources.ProyectosTemplate);

            string ProyectoHtml = "";
            string ProyectoAppender = "";

            foreach (var proyecto in Usuario.Proyectos)
            {

                ProyectoAppender =
                 (string)ProyectoBaseHtml.Clone();

                ProyectoAppender =
                  ProyectoAppender.Replace("{anoinicio}",
                  proyecto.Ano_Inicio.Year.ToString());

                if (proyecto.Ano_Inicio.Year == ((DateTime)proyecto.Ano_Fin).Year)
                {
                    
                    ProyectoAppender =
                    ProyectoAppender.Replace("{anofin}","");

                }
                else {
                    ProyectoAppender =
                    ProyectoAppender.Replace("{anofin}",
                    "-"+((DateTime)proyecto.Ano_Fin).Year.ToString());
                }

                    ProyectoAppender =
                    ProyectoAppender.Replace("{proyecto}",proyecto.Descripcion);

                    ProyectoAppender =
                    ProyectoAppender.Replace("{empresa}", proyecto.Empresa);

                    ProyectoHtml = ProyectoHtml + ProyectoAppender;

            }
            #endregion

            Html = Html.Replace("{experiencialaboral}", ExperienciaLaboralHtml);
            Html = Html.Replace("{formacionacademica}", FormacionAcademicaHtml);
            Html = Html.Replace("{proyecto}", ProyectoHtml);
            Html = Html.Replace("{formacionprofesional}", FormacionProfesionalHtml);
            byte[] pdfBytes = this.generatePDF(Html); 
            System.IO.FileStream _FileStream =
            new System.IO.FileStream(Logic.LogicResources.DocumentsUrl + Empleado.correo_e + Logic.LogicResources.DocumentsOutPutFormat,
            System.IO.FileMode.Create, System.IO.FileAccess.Write);
            _FileStream.Write(pdfBytes, 0, pdfBytes.Length);
            _FileStream.Close();
            return (Empleado.correo_e + Logic.LogicResources.DocumentsOutPutFormat);

        }





    }
}