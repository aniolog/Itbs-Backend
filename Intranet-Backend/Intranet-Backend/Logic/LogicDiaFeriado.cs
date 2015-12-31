using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intranet_Backend.Logic
{
    public class LogicDiaFeriado
    {
        /// <summary>
        /// 
        /// </summary>
        private Dao.Dao MyDao;

        /// <summary>
        /// 
        /// </summary>
        public LogicDiaFeriado()
        {
            this.MyDao = Dao.DaoFabric.getDaoDiaFeriado();
        }

        public Boolean isFeriado(DateTime Dia) {
            List<Model.snferiado> DiasFeriados= this.MyDao.GetAll();
            foreach (Model.snferiado looper in DiasFeriados) {
                if (looper.fecha.Date == Dia.Date) {
                    return true;
                }
            }
            return false;
        }


        public List<DateTime> DiasFeriados(DateTime FechaInicio, DateTime FechaFin) {
            var ReturnList = new List<DateTime>();
            List<Model.snferiado> DiasFeriados = this.MyDao.GetAll();
            foreach (Model.snferiado looper in DiasFeriados)
            {
                if (looper.fecha.Date>=FechaInicio.Date && looper.fecha.Date < FechaFin.Date)
                {
                    ReturnList.Add(looper.fecha);
                }
            }
            return ReturnList;
        }
       


    }
}