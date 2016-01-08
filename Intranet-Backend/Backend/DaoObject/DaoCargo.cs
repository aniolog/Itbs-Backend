using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Dao
{
    public class DaoCargo : Dao
    {
        /// <summary>
        /// 
        /// </summary>
        private Model.ITPRUEB_NEntities context;

        /// <summary>
        /// 
        /// </summary>
        public DaoCargo()
        {
            context = Dao.ProfitContext;
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
            var Cargo = from cargo in context.sncargo where cargo.co_cargo==PrimaryKey select cargo;
            return Cargo.First();
        }

        public override int HowMany()
        {
            throw new NotImplementedException();
        }

        public override bool Insert(object obj)
        {
            throw new NotImplementedException();
        }

        public override bool Update(object Obj)
        {
            throw new NotImplementedException();
        }
    }
}