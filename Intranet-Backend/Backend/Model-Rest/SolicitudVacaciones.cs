using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Model_Rest
{
    public class SolicitudVacaciones
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        public System.DateTime Fecha_Inicio { get; set; }
        public short Duracion { get; set; }
        public string Ticket_id { get; set; }
        public string Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Fecha_Inicio"></param>
        /// <param name="Duracion"></param>
        /// <param name="Ticket_Id"></param>
        /// <param name="Status"></param>
        public SolicitudVacaciones(int Id,DateTime Fecha_Inicio,short Duracion,string Ticket_Id,string Status)
        {
            this.Id = Id;
            this.Fecha_Inicio = Fecha_Inicio;
            this.Duracion = Duracion;
            this.Ticket_id = Ticket_Id;
            this.Status = Status;

        }
    }
}