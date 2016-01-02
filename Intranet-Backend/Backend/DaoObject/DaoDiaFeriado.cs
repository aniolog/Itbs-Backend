using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Dao
{
    /// <summary>
    /// Clase encargada de la persistencia de los dias feriados almacenados en profit
    /// </summary>
    public class DaoDiaFeriado:Dao
    {
        /// <summary>
        /// Contexto de profit
        /// </summary>
        private Model.ITPRUEB_NEntities context;

        /// <summary>
        /// Constructor encargado de inicializar el contexto
        /// </summary>
        public DaoDiaFeriado()
        {
            context = Dao.ProfitContext;
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
        /// Metodo encargado de devolver los dias feriado registrados en profit
        /// </summary>
        /// <returns></returns>
        public override dynamic GetAll()
        {
           
            var DiasFeriados = from feriados in context.snferiado select feriados;
            return DiasFeriados;
        }

        /// <summary>
        /// Metodo no implementado
        /// </summary>
        /// <param name="PrimaryKey"></param>
        /// <returns></returns>
        public override dynamic GetByPK(string PrimaryKey)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo encargado de retornar la cantidad de dias feriados
        /// </summary>
        /// <returns></returns>
        public override int HowMany()
        {
            var DiasFeriados = from feriados in context.snferiado select feriados;
            return DiasFeriados.Count();
        }

        /// <summary>
        /// Metodo no implementado
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Insert(object obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo no implementado
        /// </summary>
        /// <param name="Obj"></param>
        /// <returns></returns>
        public override bool Update(object Obj)
        {
            throw new NotImplementedException();
        }
    }
}