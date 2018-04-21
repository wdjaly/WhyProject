using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace whyDatabase
{
    class MyMysql:IwhyDatabaseBySQL
    {
        
        /// <summary>
        /// 连接字符串
        /// </summary>
        private string _myConnString;

        public MyMysql(string MdbPathOrServerIP = "XJDL_MIIS.lib", string user = "admin", string password = "xjdl!@#2015", string dbName = "")
        {
            _myConnString = string.Format(@"server={0};User Id={1};Persist Security Info=True;database={2};password={3};Character Set=utf8", MdbPathOrServerIP, user, dbName, password);
        }

        /// <summary>
        /// 执行一个SQL语句，并返回成功量
        /// </summary>
        /// <param name="SQL">SQL语句</param>
        /// <returns>执行SQL成功的记录数。</returns>
        public int Execute(string SQL)
        {
            using (MySqlConnection objConn = new MySqlConnection(_myConnString))
            {
                using (MySqlCommand objComm = new MySqlCommand(SQL, objConn))
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
            using (MySqlConnection objConn = new MySqlConnection(_myConnString))
            {
                using (MySqlDataAdapter objAdt = new MySqlDataAdapter(SQL, objConn))
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
