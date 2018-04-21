using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace whyDatabase
{
    class MyMssql:IwhyDatabaseBySQL
    {
        
        /// <summary>
        /// 连接字符串
        /// </summary>
        private string _myConnString;

        public MyMssql(string MdbPathOrServerIP = "XJDL_MIIS.lib", string user = "admin", string password = "xjdl!@#2015", string dbName = "")
        {
            _myConnString = string.Format(@"Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", MdbPathOrServerIP, dbName, user, password);
        }

        /// <summary>
        /// 执行一个SQL语句，并返回成功量
        /// </summary>
        /// <param name="SQL">SQL语句</param>
        /// <returns>执行SQL成功的记录数。</returns>
        public int Execute(string SQL)
        {
            using (SqlConnection objConn = new SqlConnection(_myConnString))
            {
                using (SqlCommand objComm = new SqlCommand(SQL, objConn))
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
            using (SqlConnection objConn = new SqlConnection(_myConnString))
            {
                using (SqlDataAdapter objAdt = new SqlDataAdapter(SQL, objConn))
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
