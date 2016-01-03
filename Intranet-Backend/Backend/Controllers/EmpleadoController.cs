﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend.Controllers
{
    [RoutePrefix("api/empleados")]
    public class EmpleadoController : ApiController
    {
        [Route("{ItbsEmail}")]
        public IQueryable<Model.snemple> Get([FromUri] string ItbsEmail)
        {
            Logic.LogicEmpleado MyLogic = new Backend.Logic.LogicEmpleado();
            return MyLogic.GetEmpleado(ItbsEmail);
        }

        [Route("")]
        public IQueryable<Model.snemple> Get()
        {
            Logic.LogicEmpleado MyLogic = new Backend.Logic.LogicEmpleado();
            return MyLogic.GetAllEmpleados();
        }

        [Route("update")]
        public Boolean Put([FromBody]Model.snemple Employee)
        {
            Logic.LogicEmpleado MyLogic = new Backend.Logic.LogicEmpleado();
            return MyLogic.ModifyEmpleado(Employee);
        }
    }
}
