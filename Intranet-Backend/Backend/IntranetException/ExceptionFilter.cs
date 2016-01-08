using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
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
                    Content = new ObjectContent<Model_Rest.Error>(
                             new Model_Rest.Error(Status,Message),
                               new JsonMediaTypeFormatter(),
                               "application/json"),
                  
                 };


                //Create the Error Response

                actionExecutedContext.Response = response;
            }
            else if (actionExecutedContext.Exception is Exception)
            {

                var Excep = (actionExecutedContext.Exception);
                var Message = Excep.Message;



                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new ObjectContent<Model_Rest.Error>(
                             new Model_Rest.Error(HttpStatusCode.InternalServerError, Message),
                               new JsonMediaTypeFormatter(),
                               "application/json"),

                };


                //Create the Error Response

                actionExecutedContext.Response = response;
            }

        }

    }
}