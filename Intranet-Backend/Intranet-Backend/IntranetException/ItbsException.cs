using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Intranet_Backend.IntranetException
{
    public class ItbsException:HttpException
    {
        public HttpStatusCode Code { get; }

        public ItbsException(HttpStatusCode Code,String Message) : base(Message)
        {
            
            this.Code=Code;

        }
    }
}