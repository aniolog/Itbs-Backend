using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Dao
{
    public class DaoProyecto : Dao
    {
        private Model.ModelbackupContainer context;

        public DaoProyecto()
        {
            this.context = Dao.IntranetContext;    
        }

        public override bool Delete(string PrimaryKey)
        {
            throw new NotImplementedException();
        }

        public override dynamic GetAll()
        {
            throw new NotImplementedException();
        }

        public override dynamic GetByPK(string PrimaryKey)
        {
            throw new NotImplementedException();
        }

        public override int HowMany()
        {
            throw new NotImplementedException();
        }

        public override bool Insert(object obj)
        {
            try{ 
            Model.Proyectos NewProject = (Model.Proyectos)obj;
            this.context.ProyectosSet.Add(NewProject);
            this.context.SaveChanges();
            return true;
            }
            catch (Exception e) {
                throw e;
            }
}

        public override bool Update(object Obj)
        {
            throw new NotImplementedException();
        }
    }
}