using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;

namespace whyDatabase
{
    class MyOracle:IwhyDatabaseBySQL
    {

        /// <summary>
        /// 连接字符串
        /// </summary>
        private string _myConnString;

        public MyOracle (string MdbPathOrServerIP, string user, string password, string dbName = "")
        {
            _myConnString = string.Format(@"Data Source={0};Persist Security Info=True;User ID={1};Password={2}", MdbPathOrServerIP, user, password);
        }

        /// <summary>
        /// 执行一个SQL语句，并返回成功量
        /// </summary>
        /// <param name="SQL">SQL语句</param>
        /// <returns>执行SQL成功的记录数。</returns>
        public int Execute(string SQL)
        {
            using (OracleConnection objConn = new OracleConnection(_myConnString))
            {
                using (OracleCommand objComm = new OracleCommand(SQL, objConn))
                {
                    objConn.Open();
                    return objComm.ExecuteNonQuery();
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
            using (OracleConnection objConn = new OracleConnection(_myConnString))
            {
                using (OracleDataAdapter objAdt = new OracleDataAdapter(SQL, objConn))
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
