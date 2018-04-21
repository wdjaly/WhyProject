using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace whyDatabase
{
    class MyAccess : IwhyDatabaseBySQL
    {
        
        /// <summary>
        /// 连接字符串
        /// </summary>
        private string _myConnString;

        public MyAccess(string MdbPathOrServerIP = "XJDL_MIIS.lib", string user = "admin", string password = "xjdl!@#2015", string dbName = "")
        {
            if (password.Length > 0)
                _myConnString = string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Persist Security Info=True;Jet OLEDB:Database Password={1}", MdbPathOrServerIP, password);
            else
                _myConnString = string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Persist Security Info=True", MdbPathOrServerIP);
        }

        /// <summary>
        /// 执行一个SQL语句，并返回成功量
        /// </summary>
        /// <param name="SQL">SQL语句</param>
        /// <returns>执行SQL成功的记录数。</returns>
        public int Execute(string SQL)
        {
            using (OleDbConnection objConn = new OleDbConnection(_myConnString))
            {
                using (System.Data.Common.DbCommand objComm = new OleDbCommand(SQL, objConn))
                {
                    objConn.Open();
                    int iR = objComm.ExecuteNonQuery();

                    objConn.Close();

                    return iR;
                }
            }
        }

        /// <summary>
        /// 查询一个SQL语句，并返回结果
        /// </summary>
        /// <param name="SQL"></param>
        /// <returns>把查询结果以表的形式返回</returns>
        public DataTable Query(string SQL)
        {
            using (OleDbConnection objConn = new OleDbConnection(_myConnString))
            {
                using (OleDbDataAdapter objAdt = new OleDbDataAdapter(SQL, objConn))
                {
                    DataSet objDs = new DataSet();

                    objConn.Open();

                    objAdt.Fill(objDs);

                    objConn.Close();

                    return objDs.Tables[0];
                }
            }
        }
    }
}
