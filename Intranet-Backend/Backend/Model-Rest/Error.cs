using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Backend.Model_Rest
{
    public class Error
    {
        public string Message;
        public HttpStatusCode Code;


        public Error(HttpStatusCode Code,String Message)
        {
            this.Message = Message;
            this.Code = Code;
        }
    }
}