using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet_Backend.Model_Rest
{
    public class Error
    {
        public string Message;
        public int Code;


        public Error(int Code,String Message)
        {
            this.Message = Message;
            this.Code = Code;
        }
    }
}