using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace whyDatabase
{
    class MssqlManager : DBManager
    {
        public MssqlManager()
        {          
        }
        /// <summary>
        /// 创建一个Mssql数据库对象
        /// </summary>
        public override void CreateDatabase(string HostOrPath = "", string UName = "sa", string UPassword = "", string DBaseName = "")
        {
            this._myDB = new MyMssql(HostOrPath, UName, UPassword, DBaseName);
        }
    }
}
