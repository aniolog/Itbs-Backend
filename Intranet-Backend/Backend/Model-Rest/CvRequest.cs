using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Model_Rest
{
    public class CvRequest
    {
        List<Model.Certificado> Certificados;
        string FileName;

        public CvRequest(List<Model.Certificado> Certificados, string FileName)
        {
            this.Certificados = Certificados;
            this.FileName = FileName;
        }

    }
}