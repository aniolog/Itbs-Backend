using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Backend.Dao
{
    /// <summary>
    /// 
    /// </summary>
    public class DaoUser:Dao
    {
        /// <summary>
        /// 
        /// </summary>
        private Model.itbsEntities context;

        /// <summary>
        /// 
        /// </summary>
        public DaoUser()
        {
            this.context = Dao.IntranetContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PrimaryKey"></param>
        /// <returns></returns>
        public override bool Delete(string PrimaryKey)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override dynamic GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Page"></param>
        /// <param name="Size"></param>
        /// <returns></returns>
        public override dynamic GetAll(int Page, int Size)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PrimaryKey"></param>
        /// <returns></returns>
        public override dynamic GetByPK(string PrimaryKey)
        {
            var User = from user in this.context.UserSet where user.Correo.Equals(PrimaryKey) select user;
            if (User.Count() < 1) {
                throw new IntranetException.ItbsException(HttpStatusCode.NotFound,IntranetException.ExceptionResource.UsuarioInexistente);
            }
            return User.First(); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int HowMany()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
                Model.User NewUser = ((Model.User)obj);
                this.context.UserSet.Add(NewUser);
                this.context.SaveChanges();
                return true;
          
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Obj"></param>
        /// <returns></returns>
        public override bool Update(object Obj)
        {
            try {
                Model.User UpdateUser = (Model.User)Obj;
                var User = from user in this.context.UserSet where user.Correo.Equals(UpdateUser.Correo) select user;
                Model.User ModifyUser=User.First();
                ModifyUser.AnoVehiculo = UpdateUser.AnoVehiculo;
                ModifyUser.ColorVehiculo = UpdateUser.ColorVehiculo;
                ModifyUser.ModeloVehiculo = UpdateUser.ModeloVehiculo;
                this.context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}