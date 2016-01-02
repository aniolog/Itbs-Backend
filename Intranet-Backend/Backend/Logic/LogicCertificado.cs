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
            if (Result.Count() == 0) {
                throw new IntranetException.ItbsException(HttpStatusCode.NoContent,IntranetException.ExceptionResource.Sin_certificados);
            }
            return Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Cert"></param>
        /// <returns></returns>
        public Boolean InsertCertificado(Model.Certificado Cert) {
            return this.MyDao.Insert(Cert);
        }
        
    }
}