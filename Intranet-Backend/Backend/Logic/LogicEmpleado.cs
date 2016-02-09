using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Backend.Logic
{
    public class LogicEmpleado
    {
        /// <summary>
        /// 
        /// </summary>
        private Dao.Dao MyDao;

        /// <summary>
        /// 
        /// </summary>
        public LogicEmpleado()
        {
            this.MyDao = Dao.DaoFabric.getDaoEmpleado();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Correo"></param>
        /// <returns></returns>
        public IQueryable<Model.snemple> GetEmpleado(String Correo) {
            return this.MyDao.GetByPK(Correo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Employee"></param>
        /// <returns></returns>
        public Boolean ModifyEmpleado(Model.snemple Employee) {
            if (Employee.correo_e == null) {
                throw new IntranetException.ItbsException(HttpStatusCode.BadRequest,IntranetException.ExceptionResource.EmpleadoInexistente);
            }
            if (this.GetEmpleado(Employee.correo_e).Count()<1) {
                throw new IntranetException.ItbsException(HttpStatusCode.BadRequest, IntranetException.ExceptionResource.EmpleadoInexistente);
            }
            return MyDao.Update(Employee);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IQueryable<Model.snemple> GetAllEmpleados() {
            return this.MyDao.GetAll();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int HowManyEmployess() {
           IQueryable<Model.snemple> List=this.MyDao.GetAll();
            return List.Count();
        }



    }
}