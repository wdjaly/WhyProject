using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace whyDatabase
{
    abstract class DBManager
    {
        //数据库对象
        protected IwhyDatabaseBySQL _myDB;
        public abstract void CreateDatabase(string HostOrPath, string UName, string UPassword, string DBaseName);
        /// <summary>
        /// 查询SQL，并返回结果表
        /// </summary>
        /// <param name="SQL"></param>
        /// <returns></returns>
        public virtual DataTable Query(string SQL)
        {
            try
            {
               return _myDB.Query(SQL);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 执行SQL，并返回成功的记录数
        /// </summary>
        /// <param name="SQL"></param>
        /// <returns></returns>
        public virtual int Execute(string SQL)
        {
            try
            {
                return _myDB.Execute(SQL);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
