using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;


namespace Backend.IntranetException
{
    public class ExceptionFilter:ExceptionFilterAttribute,IExceptionFilter
    {

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is ItbsException) {

                var Excep = ((ItbsException)actionExecutedContext.Exception);
                var Status = Excep.Code;
                var Message = Excep.Message;
                

                
                 HttpResponseMessage response = new HttpResponseMessage(Status)
                 {
                     Content = new StringContent(Message),
                     ReasonPhrase = Message
                 };


                //Create the Error Response

                actionExecutedContext.Response = response;
            }

        }

    }
}