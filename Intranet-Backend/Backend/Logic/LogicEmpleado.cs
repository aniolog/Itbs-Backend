using System;
using System.Collections.Generic;
using System.Linq;
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
        public Model.snemple GetEmpleado(String Correo) {
            return this.MyDao.GetByPK(Correo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Employee"></param>
        /// <returns></returns>
        public Boolean ModifyEmpleado(Model.snemple Employee) {
            return MyDao.Update(Employee);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Model.snemple> GetAllEmpleados() {
            return this.MyDao.GetAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Page"></param>
        /// <param name="Size"></param>
        /// <returns></returns>
        public List<Model.snemple> GetAllGetAllEmpleados(int Page,int Size) {
            return this.MyDao.GetAll(Page,Size);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int HowManyEmployess() {
            return this.MyDao.HowMany();
        }



    }
}