using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend.Controllers
{
    [RoutePrefix("api/documentos")]
    public class DocumentosController : ApiController
    {
        [Route("cv")]
        public Boolean Post([FromBody] Model.User User)
        {
            var htmlContent = String.Format("<body>" + User.Correo + "</body>",
            DateTime.Now);
            var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
            var pdfBytes = htmlToPdf.GeneratePdf(htmlContent);
            System.IO.FileStream _FileStream =
            new System.IO.FileStream(@"C:\Users\alozano\Desktop\cv.pdf", System.IO.FileMode.Create, System.IO.FileAccess.Write);
            _FileStream.Write(pdfBytes, 0, pdfBytes.Length);
            _FileStream.Close(); 
            return true;
        }
        /*
        [Route("{ItbsEmail}")]
        public byte[] CV([FromUri]string ItbsEmail) {
            var htmlContent = String.Format("<body>"+ ItbsEmail + "</body>",
             DateTime.Now);
            var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
            var pdfBytes = htmlToPdf.GeneratePdf(htmlContent);
            System.IO.FileStream _FileStream =
            new System.IO.FileStream(@"C:\Users\alozano\Desktop\cv.pdf", System.IO.FileMode.Create,System.IO.FileAccess.Write);
            _FileStream.Write(pdfBytes, 0, pdfBytes.Length);
            _FileStream.Close();
            return pdfBytes;*/
    }
    
}



