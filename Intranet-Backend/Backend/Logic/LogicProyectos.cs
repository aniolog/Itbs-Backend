using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Logic
{
    public class LogicProyectos
    {
        Dao.Dao MyDao;
        public LogicProyectos()
        {
            this.MyDao= Dao.DaoFabric.getDaoProyecto();
        }
        public bool SaveProyect(Model.Proyectos Proyect) {
            if (Proyect.Ano_Fin != null)
            {
                if (Proyect.Ano_Fin < Proyect.Ano_Inicio)
                {
                    throw new IntranetException.ItbsException(
                        System.Net.HttpStatusCode.BadRequest, "Hola");
                }
            }
            else {
                Proyect.Ano_Fin = Proyect.Ano_Inicio;
            }
            Proyect.User= (new Logic.LogicUser()).GetUser(HttpContext.Current.User.Identity.Name);
            Proyect.UserId = Proyect.User.Id;
            Proyect.UserUsename = Proyect.User.Usename;
            return this.MyDao.Insert(Proyect);
        }
    }
}