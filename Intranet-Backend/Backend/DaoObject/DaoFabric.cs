using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Dao
{
     static public class DaoFabric
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public Dao getDaoCertificado() { return new DaoCertificado(); }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public Dao getDaoCurso() { return new DaoCurso(); }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public Dao getDaoDiaFeriado() { return new DaoDiaFeriado(); }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public Dao getDaoEmpleado() { return new DaoEmpleado(); }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public Dao getDaoEstudio() { return new DaoEstudio(); }

        /// <summary>
        /// 
        /// </summary>
        static public Dao getDaoExperienciaLaboral() { return new DaoExperienciaLaboral(); }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public Dao getDaoPago() { return new DaoPago(); }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public Dao getDaoSolicitudVacaciones() { return new DaoSolicitudVacaciones(); }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public Dao getDaoUser() { return new DaoUser(); }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public Dao getDaoRol() { return new DaoRol(); }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public Dao getDaoProyecto() { return new DaoProyecto(); }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public Dao getDaoLog() { return new DaoLog(); }




    }
}