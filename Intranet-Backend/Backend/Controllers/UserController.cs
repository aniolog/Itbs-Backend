using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend.Controllers
{
    [RoutePrefix("api/usuarios")]
    public class UserController : ApiController
    {
        [Route("{ItbsEmail}")]
        public IQueryable<Model.User> Get([FromUri] string ItbsEmail)
        {
            Logic.LogicUser MyLogic = new Backend.Logic.LogicUser();
            List<Model.User> returner = new List<Model.User>();
            returner.Add(MyLogic.GetUser(ItbsEmail));
            return returner.AsQueryable();
        }

        [Route("")]
        public IQueryable<Model.User> Get()
        {
            Logic.LogicUser MyLogic = new Backend.Logic.LogicUser();
            return MyLogic.GetUsers();
        }

        [Route("create")]
        public Boolean Post([FromBody]Model.User NewUser)
        {
            Logic.LogicUser MyLogic = new Backend.Logic.LogicUser();
            return MyLogic.InsertUser(NewUser);
        }
    }
}
