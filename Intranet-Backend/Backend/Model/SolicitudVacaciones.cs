//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Backend.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class SolicitudVacaciones
    {
        public int Id { get; set; }
        public System.DateTime Fecha_Inicio { get; set; }
        public short Duracion { get; set; }
        public string Ticket_id { get; set; }
        public System.DateTime Fecha_Fin { get; set; }
        public string Estatus { get; set; }
    
        public virtual User User { get; set; }
    }
}
