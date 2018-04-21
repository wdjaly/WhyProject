using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace whyDatabase
{
    interface IwhyDatabaseBySQL
    {
        /// <summary>
        /// 执行一个SQL语句，并返回成功量
        /// </summary>
        /// <param name="SQL">SQL语句</param>
        /// <returns>执行SQL成功的记录数。</returns>
        int Execute(string SQL);
        /// <summary>
        /// 查询一个SQL语句，并返回结果
        /// </summary>
        /// <param name="SQL"></param>
        /// <returns>把查询结果以表的形式返回</returns>
        DataTable Query(string SQL);        
    }
}
