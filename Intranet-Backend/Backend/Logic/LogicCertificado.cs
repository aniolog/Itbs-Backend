using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Backend.Logic
{
    public class LogicCertificado
    {
        /// <summary>
        /// 
        /// </summary>
        private Dao.Dao MyDao;

        /// <summary>
        /// 
        /// </summary>
        public LogicCertificado()
        { 
            this.MyDao = Dao.DaoFabric.getDaoCertificado();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserEmail"></param>
        /// <returns></returns>
        public IQueryable<Model.Certificado> GetCertificados(String UserEmail) {
            IQueryable<Model.Certificado> Result = this.MyDao.GetByPK(UserEmail);
            return Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Cert"></param>
        /// <returns></returns>
        public Boolean InsertCertificado(Model.Certificado Cert) {
            if (Cert.User == null) {
                throw new IntranetException.ItbsException(HttpStatusCode.BadRequest,IntranetException.ExceptionResource.UsuarioInvalido);
            }
            var User= (new Logic.LogicUser()).GetUser(Cert.User.Correo);
            if (User == null) {
                throw new IntranetException.ItbsException(HttpStatusCode.NotFound, IntranetException.ExceptionResource.UsuarioInexistente);
            }
            Cert.User = User;
            return this.MyDao.Insert(Cert);
        }
        
    }
}