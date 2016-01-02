using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Dao
{
    /// <summary>
    /// Clase encargada de el acceso y persistencia de los certificados
    /// de los empleados
    /// </summary>
    public class DaoCertificado:Dao
    {
        /// <summary>
        /// Contexto de la base de datos Intranet
        /// </summary>
        private Model.itbsEntities context;
        
        /// <summary>
        /// Constructor de la case, unicamente inicializa el contexto
        /// </summary>
        public DaoCertificado()
        {
            this.context = Dao.IntranetContext;
        }
        /// <summary>
        /// Metodo no implementado
        /// </summary>
        /// <param name="PrimaryKey"></param>
        /// <returns></returns>
        public override bool Delete(string PrimaryKey)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo no implementado
        /// </summary>
        /// <returns></returns>
        public override dynamic GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo encargado de devolver la lista de certificados de un empleado especifico
        /// </summary>
        /// <param name="PrimaryKey">Clave del empleado al cual se le quiere obtener sus certificados</param>
        /// <returns>Lista de certificados del empleado</returns>
        public override dynamic GetByPK(string PrimaryKey)
        {
            var Cert = from cert in context.CertificadoSet  where PrimaryKey.Equals(cert.User.Correo) select cert;
            return Cert;
        }

        public override int HowMany()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo encargado de almacenar un certificado
        /// </summary>
        /// <param name="obj">Certificado a almacenar</param>
        /// <returns>True si se logro insertar con exito</returns>
        public override bool Insert(object obj)
        {
            try
            {
                Model.Certificado MyCert = (Model.Certificado)obj;
                this.context.CertificadoSet.Add(MyCert);
                this.context.SaveChanges();
                return true;
            }
            catch (Exception e) {
                throw e;
            }
        
        }

        /// <summary>
        /// Metodo no implementado
        /// </summary>
        /// <param name="PrimaryKey"></param>
        /// <returns></returns>
        public override bool Update(object Obj)
        {
            throw new NotImplementedException();
        }

      

    }
}