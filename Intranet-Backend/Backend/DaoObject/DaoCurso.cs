using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Dao
{
    /// <summary>
    /// Clase encargada de el acceso y persistencia de los cursos
    /// de los empleados
    /// </summary>
    public class DaoCurso:Dao
    {
        /// <summary>
        /// Contexto de la base de datos Intranet
        /// </summary>
        private Model.itbsEntities context;

        /// <summary>
        /// Constructor de la case, unicamente inicializa el contexto
        /// </summary>
        public DaoCurso()
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
        /// Metodo no implementado
        /// </summary>
        /// <param name="Page"></param>
        /// <param name="Size"></param>
        /// <returns></returns>
        public override dynamic GetAll(int Page, int Size)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo encargado de devolver los cursos de un empleado
        /// </summary>
        /// <param name="PrimaryKey"></param>
        /// <returns></returns>
        public override dynamic GetByPK(string PrimaryKey)
        {
            var Course = from course in context.CursosSet where PrimaryKey.Equals(course.User.Correo) select course;
            return Course;
        }

        /// <summary>
        /// Metodo no implementado
        /// </summary>
        /// <returns></returns>
        public override int HowMany()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo encargado de insertar un nuevo curso
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True si se inserto con exito</returns>
        public override bool Insert(object obj)
        {
            try {
                Model.Curso MyCourse = (Model.Curso)obj;
                this.context.CursosSet.Add(MyCourse);
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