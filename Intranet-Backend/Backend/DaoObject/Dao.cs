﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Dao
{
    public abstract class Dao
    {
        /// <summary>
        /// 
        /// </summary>
        static readonly  private  Model.ITPRUEB_NEntities ProfitContextInstance = new Model.ITPRUEB_NEntities();

        /// <summary>
        /// 
        /// </summary>
        static readonly private Model.ModelbackupContainer  IntranetContextInstance = new Model.ModelbackupContainer();

        /// <summary>
        /// 
        /// </summary>
        public static Model.ModelbackupContainer IntranetContext {
            get {
               return  IntranetContextInstance;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Model.ITPRUEB_NEntities ProfitContext
        {
            get
            {
                return ProfitContextInstance;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract dynamic GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract Boolean Insert(Object obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PK"></param>
        /// <returns></returns>
        public abstract dynamic GetByPK(String PrimaryKey);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PK"></param>
        public abstract Boolean Update(Object Obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PK"></param>
        public abstract Boolean Delete(String PrimaryKey);


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract int HowMany();


    }
}