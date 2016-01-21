using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Backend.Logic
{
    /// <summary>
    /// Clase encargada de la logica de los usuarios de intranet
    /// </summary>
    public class LogicUser
    {
        /// <summary>
        /// 
        /// </summary>
        private Dao.DaoUser Dao;

        /// <summary>
        /// 
        /// </summary>
        public LogicUser()
        {
            this.Dao = new Backend.Dao.DaoUser();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="NewUser"></param>
        /// <returns></returns>
        public Boolean InsertUser(Model.User NewUser) {

            
                if (NewUser.Rol == null)
                {
                    throw new IntranetException.ItbsException(HttpStatusCode.BadRequest, IntranetException.ExceptionResource.RolInvalido);
                }
                var Auth = (new Logic.LogicUser()).GetUser(NewUser.Correo);
                if (Auth!= null)
                {
                    throw new IntranetException.ItbsException(HttpStatusCode.BadRequest, IntranetException.ExceptionResource.UsuarioExistente);
                }
                var Rol = (new Logic.LogicRol()).GetRol(NewUser.Rol.Nombre);
                if (Rol.Count() == 0)
                {
                    throw new IntranetException.ItbsException(HttpStatusCode.BadRequest, IntranetException.ExceptionResource.RolInexistente);
                }
                var Empleado = (new Logic.LogicEmpleado()).GetEmpleado(NewUser.Correo);
                if (Empleado.Count() == 0)
                {
                    throw new IntranetException.ItbsException(HttpStatusCode.BadRequest, IntranetException.ExceptionResource.UsuarioInexistenteProfit);
                }

            NewUser.Rol = Rol.First();
                return this.Dao.Insert(NewUser);
            
           
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserEmail"></param>
        /// <returns></returns>
        public Model.User GetUser(String UserEmail) {
            return this.Dao.GetByPK(UserEmail);
        }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
        public IQueryable<Model.User> GetUsers()
        {
            return this.Dao.GetAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        public Boolean ModifyUser(Model.User User) {
            if (User.Rol == null)
            {
                throw new IntranetException.ItbsException(HttpStatusCode.BadRequest, IntranetException.ExceptionResource.RolInvalido);
            }
            var Auth = (new Logic.LogicUser()).GetUser(User.Correo);
            if (Auth == null)
            {
                throw new IntranetException.ItbsException(HttpStatusCode.BadRequest, IntranetException.ExceptionResource.UsuarioInexistente);
            }
            var Rol = (new Logic.LogicRol()).GetRol(User.Rol.Nombre);
            if (Rol.Count() == 0)
            {
                throw new IntranetException.ItbsException(HttpStatusCode.BadRequest, IntranetException.ExceptionResource.RolInexistente);
            }
            User.Rol = Rol.First();
            return this.Dao.Update(User);
        }


        public List<string> NotInUserEmail() {
            List<string> result = new List<string>();
            Logic.LogicEmpleado EmpLogic = new LogicEmpleado();
            Logic.LogicUser UsLogic = new LogicUser();

            List<Model.snemple> EmpList = EmpLogic.GetAllEmpleados().ToList();
            List<Model.User> UsList = UsLogic.GetUsers().ToList();

            foreach (var emp in EmpList) {
                var exist = false;
                foreach (var us in UsList) {
                    if (us.Correo == emp.correo_e) {
                        exist = true;
                    }

                }
                if (!(exist)) {
                    result.Add(emp.correo_e);
                }
            }
            return result;
        }

    }
}