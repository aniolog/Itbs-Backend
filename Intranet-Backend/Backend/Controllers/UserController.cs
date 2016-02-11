using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Backend.Controllers
{
    [RoutePrefix("api/usuarios")]
    public class UserController : ApiController
    {
        string root = Path.Combine(@"C:\temp\", "fotos");


        [ActionFilters.Filter]
        [Authorize(Roles = "Administrador,RecursosHumanos")]
        [Queryable]
        [Route("{ItbsEmail}")]
        public IQueryable<Model.User> Get([FromUri] string ItbsEmail)
        {
            Logic.LogicUser MyLogic = new Backend.Logic.LogicUser();
            List<Model.User> returner = new List<Model.User>();
            returner.Add(MyLogic.GetUser(ItbsEmail));
            return returner.AsQueryable();
        }


        [ActionFilters.Filter]
        [Authorize(Roles = "Administrador,RecursosHumanos")]
        [Queryable]
        [Route("")]
        public IQueryable<Model.User> Get()
        {
            Logic.LogicUser MyLogic = new Backend.Logic.LogicUser();
            return MyLogic.GetUsers();
        }


        [ActionFilters.Filter]
        [Authorize(Roles = "Administrador")]
        [Route("create")]
        public Boolean Post([FromBody]Model.User NewUser)
        {
            Logic.LogicUser MyLogic = new Backend.Logic.LogicUser();
            return MyLogic.InsertUser(NewUser);
        }


        [ActionFilters.Filter]
        [Authorize]
        [Route("update")]
        public Boolean Put([FromBody]Model_Rest.UserEmpleado Request)
        {
            Model.User UpdateUser = new Model.User();
            Logic.LogicUser UserLogic = new Backend.Logic.LogicUser();
            UpdateUser.Correo = Request.correo_e;
            UpdateUser.ModeloVehiculo = Request.ModeloVehiculo;
            UpdateUser.AnoVehiculo = Request.AnoVehiculo;
            UpdateUser.ColorVehiculo = Request.ColorVehiculo;
            UpdateUser.PlacaVehiculo = Request.PlacaVehiculo;
            UpdateUser.CorreoPersonal = Request.CorreoPersonal;
            UpdateUser.Rol = Request.rol;
            UpdateUser.Foto=(new Logic.LogicUser()).GetUser(HttpContext.Current.User.Identity.Name).Foto;
            

            Model.snemple UpdateEmployee= new Model.snemple();
            UpdateEmployee.correo_e = Request.correo_e;
            UpdateEmployee.avisar_a = Request.avisar_a;
            UpdateEmployee.telf_contact = Request.telf_contact;
            UpdateEmployee.direccion = Request.direccion;
            UpdateEmployee.telefono = Request.telefono;
            Logic.LogicEmpleado EmployeeLogic = new Backend.Logic.LogicEmpleado();
            return UserLogic.ModifyUser(UpdateUser) && EmployeeLogic.ModifyEmpleado(UpdateEmployee) ;
        }


        [ActionFilters.Filter]
        [Queryable]
        [Route("perfil")]
        [Authorize]
        public IQueryable<Model.User> GetProfile()
            {
            Logic.LogicUser MyLogic = new Backend.Logic.LogicUser();
            List<Model.User> returner = new List<Model.User>();
            returner.Add(MyLogic.GetUser(HttpContext.Current.User.Identity.Name));
            return returner.AsQueryable();
          }


        [ActionFilters.Filter]
        [Route("emailnotinuse")]
        [Authorize(Roles = "Administrador")]
        public List<string> GetNotInUseEmail()
        {
            Logic.LogicUser MyLogic = new Backend.Logic.LogicUser();
            return MyLogic.NotInUserEmail();
            
        }

       
       
    }
}
