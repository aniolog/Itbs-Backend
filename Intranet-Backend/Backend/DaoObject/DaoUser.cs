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
        private Model.ModelbackupContainer context;

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
            var User = from user in this.context.UserSet select user;
            return User;
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
               return null;
            }
            return User.First(); 
        }

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

            try
            {
                Model.User NewUser = ((Model.User)obj);
                this.context.UserSet.Add(NewUser);
                this.context.SaveChanges();
                return true;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                return false;
            }

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
                var User = from user in this.context.UserSet where user.Correo==UpdateUser.Correo select user;
                Model.User ModifyUser=User.First();
                ModifyUser.AnoVehiculo = UpdateUser.AnoVehiculo;
                ModifyUser.ColorVehiculo = UpdateUser.ColorVehiculo;
                ModifyUser.ModeloVehiculo = UpdateUser.ModeloVehiculo;
                ModifyUser.Foto = UpdateUser.Foto;
                ModifyUser.CorreoPersonal = UpdateUser.CorreoPersonal;
                ModifyUser.PlacaVehiculo = UpdateUser.PlacaVehiculo;
                ModifyUser.Rol = UpdateUser.Rol;
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